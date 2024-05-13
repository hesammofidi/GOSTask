using Application.Contract.Persistance.EFCore;
using Application.Dtos.OrderDtos;
using Application.Dtos.OrderDtos.Validators;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrdersFeatures.Commands
{
    public class OrderRequestsHandlersCommand
    {
        #region AddOrder
        public class AddOrderRequestCommand : IRequest<BaseCommandResponse>
        {
            public AddOrderDto? OrderDto { get; set; }
        }
        public class AddOrderHandlerCommand : IRequestHandler<AddOrderRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IOrdersRepository _OrderRepository;
            public AddOrderHandlerCommand(IMapper mapper, IOrdersRepository OrderRepository)
            {
                _mapper = mapper;
                _OrderRepository = OrderRepository;
            }
            public async Task<BaseCommandResponse> Handle(AddOrderRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddOrderValidator();
                var validationResult = await validator.ValidateAsync(request.OrderDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var OrderInfo = _mapper.Map<Orders>(request.OrderDto);
                    await _OrderRepository.AddAsync(OrderInfo);
                    response.Success = true;
                    response.Message = "Creation Successful";
                }
                return response;
            }
        }
        #endregion

        #region EditOrder
        public class EditOrderRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditOrderDto? OrderDto { get; set; }
        }
        public class EditOrderHandlerCommand : IRequestHandler<EditOrderRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IOrdersRepository _OrderRepository;
            public EditOrderHandlerCommand(IMapper mapper, IOrdersRepository OrderRepository)
            {
                _mapper = mapper;
                _OrderRepository = OrderRepository;
            }
            public async Task<BaseCommandResponse> Handle(EditOrderRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditOrderValidator();
                var validationResult = await validator.ValidateAsync(request.OrderDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    //var OrderInfo = _mapper.Map<Order>(request.OrderDto);
                    //await _OrderRepository.AddAsync(OrderInfo);
                    var entity = await _OrderRepository.GetByIdAsync(request.OrderDto.Id);
                    _mapper.Map(request.OrderDto, entity);
                    await _OrderRepository.UpdateAsync(entity);
                    response.Success = true;
                    response.Message = "Update Successful";
                }
                return response;
            }
        }
        #endregion

        #region DeleteOrder
        public class DeleteOrderRequestCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteOrderHandlerCommand : IRequestHandler<DeleteOrderRequestCommand>
        {
            private readonly IOrdersRepository _OrderRepository;
            public DeleteOrderHandlerCommand(IOrdersRepository OrderRepository)
            {
                _OrderRepository = OrderRepository;
            }

            public async Task Handle(DeleteOrderRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _OrderRepository.GetByIdAsync(request.Id);
                await _OrderRepository.DeleteAsync(entity);
            }
        }

        #endregion
    }
}
