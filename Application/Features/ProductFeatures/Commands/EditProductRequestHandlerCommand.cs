using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.ProductDtos;
using Application.Dtos.ProductDtos.Validators;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.ProductFeatures.Commands
{
    public class EditProductRequestHandlerCommand
    {
        public class EditProductRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditProductDto? ProductDto { get; set; }
        }
        public class EditProductHandlerCommand : IRequestHandler<EditProductRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IProductsRepository _ProductsRepository;

            public EditProductHandlerCommand(IProductsRepository ProductsRepository,
                IMapper mapper)
            {
                _ProductsRepository = ProductsRepository;
                _mapper = mapper;
            }

            public async Task<BaseCommandResponse> Handle(EditProductRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditProductValidator();
                var validationResult = await validator.ValidateAsync(request.ProductDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Update Product Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var entity = await _ProductsRepository.GetByIdAsync(request.ProductDto.Id);
                    _mapper.Map(request.ProductDto, entity);
                    await _ProductsRepository.UpdateAsync(entity);
                    response.Success = true;
                    response.Message = "Update Product Successful";
                }
                return response;
            }
        }
    }
}
