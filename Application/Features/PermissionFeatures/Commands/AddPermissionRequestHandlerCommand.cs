using Application.Contract.Identity;
using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.PermissionsDtos;
using Application.Dtos.RoleDtos.Validators;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PermissionFeatures.Commands
{
    public class AddPermissionRequestHandlerCommand
    {
        public class AddPermissionRequestCommand() : IRequest<BaseCommandResponse>
        {
            public PermissionInfoDto? permissionDto { get; set; }
        }
        public class AddPermissionHandlerCommand : IRequestHandler<AddPermissionRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPermissionsRepository _permissionRepository ;
            public AddPermissionHandlerCommand(IPermissionsRepository permissionRepository,  
                IMapper mapper)
            {
                _permissionRepository = permissionRepository;
                _mapper = mapper;
            }
            public async Task<BaseCommandResponse> Handle(AddPermissionRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new PermissionsValidator(_permissionRepository);
                var validationResult = await validator.ValidateAsync(request.permissionDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                        var pwermissionInfo = _mapper.Map<Permisions>(request.permissionDto);
                        await _permissionRepository.AddAsync(pwermissionInfo);
                        response.Success = true;
                        response.Message = "Creation Successful";
                }
                return response;
            }
        }
    }
}
