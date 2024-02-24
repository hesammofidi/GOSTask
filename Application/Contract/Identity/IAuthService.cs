using Application.Contract.Persistance;
using Application.Models.Abstraction;
using Application.Models.IdentityModels.UserModels;
using Application.Responses;
using Domain.Primitives.Contract;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Identity
{
    public interface IAuthService 
    {
        Task<AuthResponse> LoginAsync(AuthRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task EditUserAsync(DomainUser domainUser);
        Task ForgotPasswordAsync(ForgetPassDto request);
        Task<PagedList<DomainUser>> FilterUserAsync(FilterData data);
        Task<PagedList<DomainUser>> SearchUserAsync(SearchData data);
        Task ChangePasswordByAdmin(ChangePasswordDto changePassword);
        Task RessetPasswordByUser(RessetPasswordDto changePassword);
    }
}
