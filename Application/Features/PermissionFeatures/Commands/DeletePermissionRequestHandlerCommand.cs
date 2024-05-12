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
            private readonly IProductsRepository _ProductsRepository;
            public DeletePermissionHandlerCommand(IProductsRepository ProductsRepository)
            {
                _ProductsRepository = ProductsRepository;
            }
            public async Task Handle(DeletePermissionRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _ProductsRepository.GetByIdAsync(request.permissionId);
                await _ProductsRepository.DeleteAsync(entity);
            }
        }
    }
}
