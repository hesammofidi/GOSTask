using Application.Contract.Persistance.EFCore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteProductRequestHandlerCommand
    {
        public class DeleteProductRequestCommand : IRequest
        {
            public int ProductId { get; set; }
        }
        public class DeleteProductHandlerCommand : IRequestHandler<DeleteProductRequestCommand>
        {
            private readonly IProductsRepository _ProductsRepository;
            public DeleteProductHandlerCommand(IProductsRepository ProductsRepository)
            {
                _ProductsRepository = ProductsRepository;
            }
            public async Task Handle(DeleteProductRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _ProductsRepository.GetByIdAsync(request.ProductId);
                await _ProductsRepository.DeleteAsync(entity);
            }
        }
    }
}
