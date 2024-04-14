using Application.Contract.Identity;
using Application.Models.IdentityModels.UserModels;
using Domain.Users;
using Infrastructure.Mail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence.IdentityServices;
using static Application.Features.UserFeatures.Commands.AddUserRequestHandlerCommand;

namespace IdentityManagmentSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;
        private readonly UserManager<DomainUser> _usermanager;
        public AccountController(IAuthService authService, ILogger<AccountController> logger, IMediator mediator, UserManager<DomainUser> usermanager)
        {
            _authService = authService;
            _logger = logger;
            _mediator = mediator;
            _usermanager = usermanager;
        }

        [HttpPost("forgotPass")]
        public async Task<ActionResult> ForgotPassword(ForgetPassDto resetRequest)
        {
            if (resetRequest.Email == null)
            {
                return BadRequest("Email is Null");
            }
            var user = await _usermanager.FindByEmailAsync(resetRequest.Email);
            if (user == null)
            {
                return NotFound("User Not Found!");
            }
            await _authService.ForgotPasswordAsync(resetRequest);
            return Ok();
          
        }

        [HttpPost("ressetPass")]
        public async Task<ActionResult> RessetPassword(RessetPasswordDto resetRequest)
        {
            if (resetRequest.Email == null)
            {
                return BadRequest("Email is Null");
            }
            var user = await _usermanager.FindByEmailAsync(resetRequest.Email);
            if (user == null)
            {
                return NotFound("User Not Found!");
            }
            await _authService.RessetPasswordByUser(resetRequest);
            return Ok();
        }

            [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.LoginAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            var command = new AddUserRequestCommand { AddOrRegisterUserDto = request };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}

