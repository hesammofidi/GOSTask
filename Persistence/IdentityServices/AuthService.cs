using Application.Constants;
using Application.Contract.Identity;
using Application.Models.Abstraction;
using Application.Models.IdentityModels.UserModels;
using Application.Responses;
using Azure.Core;
using Domain.Primitives.Contract;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Persistence.IdentityServices
{
    public class AuthService : IAuthService
    {
        #region Ctor
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailSender<DomainUser> _sendEmail;
        private readonly UserManager<DomainUser> _usermanager;
        private readonly SignInManager<DomainUser> _signInManager;
        private readonly ILogger<AuthService> _logger;
        private DbContext _context;
        // private DbSet<TEntity> _set;
        protected DbSet<DomainUser> _set;

        public AuthService(IOptions<JwtSettings> jwtSettings,
            UserManager<DomainUser> usermanager,
            SignInManager<DomainUser> signInManager,
            IEmailSender<DomainUser> sendEmail,
            ILogger<AuthService> logger)
        {
            _jwtSettings = jwtSettings.Value;
            _usermanager = usermanager;
            _signInManager = signInManager;
            _sendEmail = sendEmail;
            _logger = logger;
        }
        #endregion

        #region ChangePasswordByUser
        public async Task ForgotPasswordAsync(ForgetPassDto resetRequest)
        {
            var user = await _usermanager.FindByEmailAsync(resetRequest.Email);
            if (user == null || !(await _usermanager.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                return;
            }
            var code = await _usermanager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            _logger.LogInformation("reset password code sent to {Email}", resetRequest.Email);
            await _sendEmail.SendPasswordResetCodeAsync(user, resetRequest.Email, HtmlEncoder.Default.Encode(code));
        }

        public Task RessetPasswordByUser(RessetPasswordDto changePassword)
        {
            throw new NotImplementedException();
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
                         .PasswordSignInAsync(user.UserName, request.Password, request.IsPersistant, true);
            if (!result.Succeeded)
            {
                throw new Exception($"credentials for {request.Email} arent valid.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponse response = new AuthResponse()
            {
                Id = user.Id,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
            };
            //string resetCode = "123456";
            //await _sendEmail.SendPasswordResetCodeAsync(user, user.Email, resetCode);
            return response;

        }
        private async Task<JwtSecurityToken> GenerateToken(DomainUser user)
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
                    //new Claim(ClaimTypes.Role,"Admin")
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
         

            var existingEmail = await _usermanager.FindByNameAsync(request.Email);
            

            if (existingEmail == null)
            {

                var user = new DomainUser
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
                    return new RegistrationResponse() 
                    {
                        UserId = user.Id,
                        UserEmail=user.Email
                    };
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

        #region FilterandSearchUser
        public async Task<PagedList<DomainUser>> FilterUserAsync(FilterData data)
        {
            return await _set
                        .AsNoTracking()
                        .Filter(data.Filter)
                        .Sort(data.Sort)
                        .PageAsync(data.PageSize, data.PageIndex);
        }
       
        public async Task<PagedList<DomainUser>> SearchUserAsync(SearchData data)
        {
            return await _set .AsNoTracking()
                .Where(user => EF.Functions.Like(user.UserName, $"%{data.SearchText}%")|| 
                               EF.Functions.Like(user.PhoneNumber, $"%{data.SearchText}%")||
                               EF.Functions.Like(user.Email, $"%{data.SearchText}%")||
                               EF.Functions.Like(user.FullName, $"%{data.SearchText}%"))
                .Sort(data.Sort)
                .PageAsync (data.PageSize, data.PageIndex);
        }
        #endregion

        #region EditUserByAdmin
        public async Task EditUserAsync(DomainUser domainUser)
        {
            // Find the user in the database
            var user = await _usermanager.FindByIdAsync(domainUser.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Update the user properties
            user.Email = domainUser.Email;
            user.UserName = domainUser.UserName;
            user.PhoneNumber = domainUser.PhoneNumber;
            user.FullName = domainUser.FullName;
            
            // Add other properties you want to update

            // Update the user
            var result = await _usermanager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("User update failed");
            }
        }

        public async Task ChangePasswordByAdmin(ChangePasswordDto changePassword)
        {
            // Find the user in the database
            var user = await _usermanager.FindByIdAsync(changePassword.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Check if the new password and confirm password match
            if (changePassword.Password != changePassword.ConfirmPassword)
            {
                throw new Exception("Passwords do not match");
            }

            // Generate a password reset token
            var token = await _usermanager.GeneratePasswordResetTokenAsync(user);

            // Reset the password
            var result = await _usermanager.ResetPasswordAsync(user, token, changePassword.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Password update failed");
            }
        }

        #endregion

    }
}

