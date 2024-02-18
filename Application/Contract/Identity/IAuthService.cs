using Application.Models.IdentityModels;
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
        Task ForgotPasswordAsync(ForgetPassDto request);
    }
}
