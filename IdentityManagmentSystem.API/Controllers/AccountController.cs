using Application.Contract.Identity;
using Application.Models.IdentityModels;
using Infrastructure.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.IdentityServices;

namespace IdentityManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAuthService authService, ILogger<AccountController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("forgotPass")]
        public async Task<ActionResult> ForgotPassword(ForgetPassDto resetRequest)
        {

            await _authService.ForgotPasswordAsync(resetRequest);
            return Ok();
            //try
            //{
            //    await _authService.ForgotPasswordAsync(resetRequest);
            //    return Ok();
            //}
            //catch (Exception ex)
            //{
            //    // Log the inner exception if it exists
            //    if (ex.InnerException != null)
            //    {
            //        _logger.LogError(ex.InnerException, "Error in ForgotPassword");
            //    }

            //    return BadRequest(ex.Message);
            //}
        }
    }
}

//[HttpPost("login")]
//public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
//{
//    return Ok(await _authService.LoginAsync(request));
//}

//[HttpPost("register")]
//public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
//{
//    return Ok(await _authService.RegisterAsync(request));
//}