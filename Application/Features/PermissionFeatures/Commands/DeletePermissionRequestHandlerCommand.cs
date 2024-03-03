using Application.Contract.Persistance.SystemsRolesManagment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PermissionFeatures.Commands
{
    public class DeletePermissionRequestHandlerCommand 
    {
        public class DeletePermissionRequestCommand : IRequest
        {
            public int permissionId { get; set; }
        }
        public class DeletePermissionHandlerCommand : IRequestHandler<DeletePermissionRequestCommand>
        {
            private readonly IPermissionsRepository _permissionRepository;
            public DeletePermissionHandlerCommand(IPermissionsRepository permissionRepository)
            {
                _permissionRepository = permissionRepository;
            }
            public async Task Handle(DeletePermissionRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _permissionRepository.GetByIdAsync(request.permissionId);
                await _permissionRepository.DeleteAsync(entity);
            }
        }
    }
}
