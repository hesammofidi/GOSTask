

using IdentityManagement.UI.Services.Contract;
using IdentityManagment.UI.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.Data;
using System.Text.Json;

namespace IdentityManagment.UI.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public AuthService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("AuthenticationAPI");
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
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
            var response = await _client.PostAsJsonAsync("register", request);
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

      
    }
}
