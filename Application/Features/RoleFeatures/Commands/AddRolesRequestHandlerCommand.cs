using Application.Contract.Identity;
using Application.Dtos.RoleDtos;
using Application.Dtos.RoleDtos.Validators;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.RoleFeatures.Commands
{
    public class AddRolesRequestHandlerCommand
    {
        public class AddRolesRequestCommand : IRequest<BaseCommandResponse>
        {
            public AddRoleDto? addRoleDto { get; set; }
        }

        public class AddRolesHandlerCommand : IRequestHandler<AddRolesRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IRoleServices _roleService;
            public AddRolesHandlerCommand(IMapper mapper, IRoleServices roleService)
            {
                _mapper = mapper;
                _roleService = roleService;
            }
            public async Task<BaseCommandResponse> Handle(AddRolesRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddRoleValidator();
                var validationResult = await validator.ValidateAsync(request.addRoleDto);
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
                         await _roleService.AddRoleAsync(request.addRoleDto);
                        response.Success = true;
                        response.Message = "Creation Successful";
                        
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
