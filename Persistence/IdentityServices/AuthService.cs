using Application.Constants;
using Application.Contract.Identity;
using Application.Models.IdentityModels;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IdentityServices
{
    public class AuthService : IAuthService
    {
        #region Ctor
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(IOptions<JwtSettings> jwtSettings,
            UserManager<User> usermanager,
            SignInManager<User> signInManager)
        {
            _jwtSettings = jwtSettings.Value;
            _usermanager = usermanager;
            _signInManager = signInManager;
        }
        #endregion

        #region Login
        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {
            var user = await _usermanager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception($"user with {request.Email} not fount.");
            }
            var result = await _signInManager
                         .PasswordSignInAsync(user.UserName, request.Password,request.IsPersistant,true);
            if (!result.Succeeded)
            {
                throw new Exception($"credentials for {request.Email} arent valid.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponse response = new AuthResponse()
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                
            };

            return response;

        }
        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await _usermanager.GetClaimsAsync(user);
            var roles = await _usermanager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        #endregion

        #region Register
        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            //    //var existingUser = await _usermanager.FindByNameAsync(request.UserName);
            //    //if (existingUser != null)
            //    //{
            //    //    throw new Exception($"user name '{request.UserName}' already exists.");
            //    //}

            //    //var user = new User
            //    //{
            //    //    Email = request.Email,
            //    //    FullName = request.FullName,

            //    //    UserName = request.UserName,
            //    //    EmailConfirmed = true
            //    //};

            var existingEmail = await _usermanager.FindByEmailAsync(request.Email);
            if (existingEmail == null)
            {

                var user = new User
                {
                    Email = request.Email,
                    FullName = request.FullName,

                    UserName = request.Email,
                    EmailConfirmed = true
                };

                var result = await _usermanager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _usermanager.AddToRoleAsync(user, "Basicuser");
                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email '{request.Email}' already exists.");
            }
        }
        #endregion
    }
}
