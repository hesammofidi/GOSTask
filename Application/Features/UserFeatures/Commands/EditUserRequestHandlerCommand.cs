using Application.Contract.Identity;
using Application.Models.IdentityModels.UserModels;
using Application.Models.IdentityModels.UserModels.Validators;
using Application.Responses;
using AutoMapper;
using Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class EditUserRequestHandlerCommand
    {
        public class EditUserRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditUserDto? editUserDto { get; set; }
        }
        public class EditUserHandlerCommand : IRequestHandler<EditUserRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IAuthService _userService;
            public EditUserHandlerCommand(IMapper mapper, IAuthService userService)
            {
                _mapper = mapper;
                _userService = userService;
            }
            public async Task<BaseCommandResponse> Handle(EditUserRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditUserValidator();
                var validationResult = await validator.ValidateAsync(request.editUserDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var userInfo =  _mapper.Map<DomainUser>(request.editUserDto);
                    await _userService.EditUserAsync(userInfo);
                    response.Success = true;
                    response.Message = "Update Successful";
                    response.Id = int.Parse( userInfo.Id );
                }
                return response;
            }


        }
    }
}
