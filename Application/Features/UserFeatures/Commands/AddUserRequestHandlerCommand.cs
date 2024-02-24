using Application.Contract.Identity;
using Application.Models.IdentityModels.UserModels;
using Application.Models.IdentityModels.UserModels.Validators;
using Application.Responses;
using AutoMapper;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class AddUserRequestHandlerCommand
    {
        public class AddUserRequestCommand : IRequest<BaseCommandResponse>
        {
            public RegistrationRequest? AddOrRegisterUserDto { get; set; }
        }

        public class AddUserHandlerCommand : IRequestHandler<AddUserRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IAuthService _userService;
            private readonly UserManager<DomainUser> _userManager;
            public AddUserHandlerCommand(IMapper mapper,
                IAuthService userService,
                UserManager<DomainUser> userManager)
            {
                _mapper = mapper;
                _userService = userService;
                _userManager = userManager;
            }
            public async Task<BaseCommandResponse> Handle(AddUserRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddUserValidator(_userService, _userManager);
                var validationResult = await validator.ValidateAsync(request.AddOrRegisterUserDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    try
                    {
                        var regResponse = await _userService.RegisterAsync(request.AddOrRegisterUserDto);
                        response.Success = true;
                        response.Message = "Creation Successful";
                        response.Id = int.Parse(regResponse.UserId);
                    }
                    catch (FormatException)
                    {
                        response.Success = false;
                        response.Message = "Creation Failed";
                        response.Errors = new List<string> { "UserId must be a valid integer." };
                    } 
                }
                return response;
            }
        }
    }
}
