using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.PermissionsDtos.Validators;
using Application.Dtos.ProductDtos;
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
            public EditProductDto? permissionDto { get; set; }
        }
        public class EditPermissionHandlerCommand : IRequestHandler<EditPermissionRequestCommand,BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IProductsRepository _ProductsRepository;

            public EditPermissionHandlerCommand(IProductsRepository ProductsRepository,  
                IMapper mapper)
            {
                _ProductsRepository = ProductsRepository;
                _mapper = mapper;
            }

            public async Task<BaseCommandResponse> Handle(EditPermissionRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditPermissionValidator(_ProductsRepository);
                var validationResult = await validator.ValidateAsync(request.permissionDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Update permission Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var entity = await _ProductsRepository.GetByIdAsync(request.permissionDto.Id);
                    _mapper.Map(request.permissionDto, entity);
                    await _ProductsRepository.UpdateAsync(entity);
                    response.Success = true;
                    response.Message = "Update permission Successful";
                }
                return response;
            }
        }
    }
}
