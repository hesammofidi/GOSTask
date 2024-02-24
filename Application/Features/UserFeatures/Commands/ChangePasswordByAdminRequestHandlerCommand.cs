using Application.Contract.Identity;
using Application.Models.IdentityModels.UserModels;
using Application.Models.IdentityModels.UserModels.Validators;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.UserFeatures.Commands
{
    public class ChangePasswordByAdminRequestHandlerCommand
    {
        public class ChangePasswordRequestCommand : IRequest<BaseCommandResponse>
        {
            public ChangePasswordDto changePasswordDto { get; set; }
        }

        public class ChangePasswordHandlerCommand : IRequestHandler<ChangePasswordRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IAuthService _userService;

            public ChangePasswordHandlerCommand(IMapper mapper, IAuthService userService)
            {
                _mapper = mapper;
                _userService = userService;
            }
            public async Task<BaseCommandResponse> Handle(ChangePasswordRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new ChangePasswordValidator();
                var validationResult = await validator.ValidateAsync(request.changePasswordDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    try
                    {
                        await _userService.ChangePasswordByAdmin(request.changePasswordDto);
                        response.Success = true;
                        response.Message = "Chnage Password Successful";
                        response.Id = int.Parse(request.changePasswordDto.UserId);
                    }
                    catch (FormatException)
                    {
                        response.Success = false;
                        response.Message = "Chnage Password Failed";
                        response.Errors = new List<string> { "UserId must be a valid ." };
                    }
                }
                return response;
            }
        }
    }
}
