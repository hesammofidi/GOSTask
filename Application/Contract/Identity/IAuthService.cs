using Application.Models.Abstraction;
using Application.Models.IdentityModels.UserModels;
using Domain.Users;

namespace Application.Contract.Identity
{
    public interface IAuthService 
    {
        Task<AuthResponse> LoginAsync(AuthRequest request);
        Task<bool> UserExist(string Id);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task EditUserAsync(DomainUser domainUser);
        Task ForgotPasswordAsync(ForgetPassDto request);
        Task<PagedList<DomainUser>> FilterUserAsync(FilterData data);
        Task<PagedList<DomainUser>> SearchUserAsync(SearchData data);
        Task ChangePasswordByAdmin(ChangePasswordDto changePassword);
        Task RessetPasswordByUser(RessetPasswordDto changePassword);
    }
}
