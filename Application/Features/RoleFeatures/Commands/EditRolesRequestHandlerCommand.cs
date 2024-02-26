using Application.Contract.Identity;
using Application.Dtos.RoleDtos;
using Application.Dtos.RoleDtos.Validators;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoleFeatures.Commands
{
    public class EditRolesRequestHandlerCommand
    {
        public class EditRolesRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditRoleDto? EditRoleDto { get; set; }
        }
        public class EditRolesHandlerCommand : IRequestHandler<EditRolesRequestCommand, BaseCommandResponse>
        {
            private readonly IRoleServices _roleService;
            public EditRolesHandlerCommand(IRoleServices roleService)
            {
                _roleService = roleService;
            }
            public async Task<BaseCommandResponse> Handle(EditRolesRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditRoleValidator();
                var validationResult = await validator.ValidateAsync(request.EditRoleDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Edit Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    try
                    {
                        await _roleService.EditRoleAsync(request.EditRoleDto);
                        response.Success = true;
                        response.Message = "Edit Successful";

                    }
                    catch (FormatException)
                    {
                        response.Success = false;
                        response.Message = "Edit Failed";
                        response.Errors = new List<string> { "UserId must be a valid integer." };
                    }

                }
                return response;
            }
            
        }
    }
}
