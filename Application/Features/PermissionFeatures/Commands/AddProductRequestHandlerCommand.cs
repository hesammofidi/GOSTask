using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.ProductDtos;
using Application.Dtos.ProductDtos.Validators;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PermissionFeatures.Commands
{
    public class AddProductRequestHandlerCommand
    {
        public class AddProductRequestCommand() : IRequest<BaseCommandResponse>
        {
            public AddProductDto? permissionDto { get; set; }
        }
        public class AddProductHandlerCommand : IRequestHandler<AddProductRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IProductsRepository _ProductsRepository ;
            public AddProductHandlerCommand(IProductsRepository ProductsRepository,  
                IMapper mapper)
            {
                _ProductsRepository = ProductsRepository;
                _mapper = mapper;
            }
            public async Task<BaseCommandResponse> Handle(AddProductRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddProductValidator();
                var validationResult = await validator.ValidateAsync(request.permissionDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                        var pwermissionInfo = _mapper.Map<Products>(request.permissionDto);
                        await _ProductsRepository.AddAsync(pwermissionInfo);
                        response.Success = true;
                        response.Message = "Creation Successful";
                }
                return response;
            }
        }
    }
}
