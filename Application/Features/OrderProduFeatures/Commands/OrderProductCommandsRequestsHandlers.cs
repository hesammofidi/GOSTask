using Application.Contract.Persistance.EFCore;
using Application.Dtos.OrderProductDtos;
using Application.Dtos.OrderProductDtos.Validators;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderProduFeatures.Commands
{
    public class OrderProductCommandsRequestsHandlers
    {

        #region AddSR
        public class AddOrderProductRequestCommand : IRequest<BaseCommandResponse>
        {
            public AddOrderProductDto? addSRDto { get; set; }
        }
        public class AddOrderProductHandlerCommand : IRequestHandler<AddOrderProductRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _OrderProductRepository;
            public AddOrderProductHandlerCommand(IMapper mapper, IOrderProductRepository OrderProductRepository)
            {
                _mapper = mapper;
                _OrderProductRepository = OrderProductRepository;
            }

            public async Task<BaseCommandResponse> Handle(AddOrderProductRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddOrderProductValidator();
                var validationResult = await validator.ValidateAsync(request.addSRDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var systemInfo = _mapper.Map<OrderProduct>(request.addSRDto);
                    await _OrderProductRepository.AddAsync(systemInfo);
                    response.Success = true;
                    response.Message = "Creation Successful";
                }
                return response;
            }
        }
        #endregion

        #region Editsr
        public class EditOrderProductRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditOrderProductDto? ediSRDto { get; set; }
        }
        public class EditOrderProductHandlerCommand : IRequestHandler<EditOrderProductRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _OrderProductRepository;
            public EditOrderProductHandlerCommand(IMapper mapper, IOrderProductRepository OrderProductRepository)
            {
                _mapper = mapper;
                _OrderProductRepository = OrderProductRepository;
            }

            public async Task<BaseCommandResponse> Handle(EditOrderProductRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditOrderProductValidator();
                var validationResult = await validator.ValidateAsync(request.ediSRDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Edit Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var systemInfo = await _OrderProductRepository.GetByIdAsync(request.ediSRDto.Id);
                    _mapper.Map(systemInfo, request.ediSRDto);
                    await _OrderProductRepository.UpdateAsync(systemInfo);
                    response.Success = true;
                    response.Message = "Edit Successful";
                }
                return response;
            }
        }
        #endregion

        #region DeleteSR
        public class DeleteOrderProductRequestCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteOrderProductHandlerCommand : IRequestHandler<DeleteOrderProductRequestCommand>
        {
            private readonly IOrderProductRepository _OrderProductRepository;
            public DeleteOrderProductHandlerCommand(IOrderProductRepository OrderProductRepository)
            {
                _OrderProductRepository = OrderProductRepository;
            }

            public async Task Handle(DeleteOrderProductRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _OrderProductRepository.GetByIdAsync(request.Id);
                await _OrderProductRepository.DeleteAsync(entity);
            }
        }
        #endregion
    }
}
