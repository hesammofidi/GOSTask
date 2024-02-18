

using IdentityManagement.UI.Services.Contract;
using IdentityManagment.UI.Client.Models;
using IdentityManagment.UI.Client;
using IdentityManagment.UI.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace IdentityManagment.UI.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        public AuthService(IHttpClientFactory factory, 
            AuthenticationStateProvider authStateProvider)
        {
            _client = factory.CreateClient("AuthenticationAPI");
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            _authStateProvider = authStateProvider;
        }

        public async Task<LoginResponseDto> LoginUser(LoginRequestDto request)
        {
            var response = await _client.PostAsJsonAsync("login", request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResponseDto>(content, _options);
            return loginResponse;
        }

        public async Task RegisterAsync(RegisterRequestDto request)
        {
            var response = await _client.PostAsJsonAsync("Account/register", request);
            response.EnsureSuccessStatusCode();
        }


        public async Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var response = await _client.PostAsJsonAsync("api/Account/forgotPass", forgotPasswordDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task RessetPasswordAsync(RessetPasswordRequestDto resetPassword)
        {
            var response = await _client.PostAsJsonAsync("resetPassword", resetPassword);
            response.EnsureSuccessStatusCode();
        }

        public async Task LoginAsync(LoginRequestDto userloginVm)
        {
            var response = await _client.PostAsJsonAsync("Account/login", userloginVm);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<LoginResponseDto>();

            if (string.IsNullOrEmpty(content!.AccessToken)) return;

            var authenticationModel = new AuthenticationModel()
            {
                Token = content.AccessToken,
                RefreshToken = content.RefreshToken,
                UserName = content.Email
            };

            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(authenticationModel);

        }
    }
}
