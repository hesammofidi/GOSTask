
using IdentityManagment.UI.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.Data;

namespace IdentityManagement.UI.Services.Contract
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginUser(LoginRequestDto request);
        Task RegisterAsync(RegisterRequestDto request);
        Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task RessetPasswordAsync(RessetPasswordRequestDto resetPassword);
    }
}
