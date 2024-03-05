using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.PermissionsDtos;
using Application.Dtos.PermissionsDtos.Validators;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PermissionFeatures.Commands
{
    public class EditPermissionRequestHandlerCommand
    {
        public class EditPermissionRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditPermissionDto? permissionDto { get; set; }
        }
        public class EditPermissionHandlerCommand : IRequestHandler<EditPermissionRequestCommand,BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPermissionsRepository _permissionRepository;

            public EditPermissionHandlerCommand(IPermissionsRepository permissionRepository,  
                IMapper mapper)
            {
                _permissionRepository = permissionRepository;
                _mapper = mapper;
            }

            public async Task<BaseCommandResponse> Handle(EditPermissionRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditPermissionValidator(_permissionRepository);
                var validationResult = await validator.ValidateAsync(request.permissionDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Update permission Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var entity = await _permissionRepository.GetByIdAsync(request.permissionDto.Id);
                    _mapper.Map(request.permissionDto, entity);
                    await _permissionRepository.UpdateAsync(entity);
                    response.Success = true;
                    response.Message = "Update permission Successful";
                }
                return response;
            }
        }
    }
}
