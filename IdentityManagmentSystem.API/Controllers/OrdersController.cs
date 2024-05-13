using Application.Contract.Persistance.EFCore;
using Application.Dtos.OrderDtos;
using Application.Dtos.ProductDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using IdentityManagmentSystem.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using static Application.Features.OrdersFeatures.Commands.OrderRequestsHandlersCommand;
using static Application.Features.OrdersFeatures.Queries.GetOrdersRequestHandlerQuery;
using static Application.Features.ProductFeatures.Queries.GetProductsRequestHandlerQuery;

namespace IdentityManagmentOrder.API.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IOrdersRepository _OrdersRepository;
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(IMediator mediator,
            IOrdersRepository OrdersRepository,
            ILogger<OrdersController> logger)
        {
            _mediator = mediator;
            _OrdersRepository = OrdersRepository;
            _logger = logger;
        }

        #region GetAllWithDapper
        [HttpGet("GetAllDapper")]
        public async Task<ActionResult<IEnumerable<OrderInfoDto>>> GetAllOrdersAsync()
        {
            try
            {
                var query = new GetAllOrdersRequestQuery { };
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion

        #region getbyIdDapper
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderInfoDto>> GetOrderByIdAsync([FromRoute] int id)
        {
            try
            {
                var Order = await _OrdersRepository.Exist(id);

                if (!Order)
                {
                    return NotFound($"Invalid OrderId : {id}");
                }

                var OrderDto = await _mediator.Send(new GetOrdersRequestQuery { OrderId = id });

                return Ok(OrderDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddOrder
         ([FromBody] AddOrderDto data)
        {
            try
            {
                var command = new AddOrderRequestCommand { OrderDto = data };
                var commandResponse = await _mediator.Send(command);
                return commandResponse.Success ? Ok(commandResponse) : StatusCode(400, commandResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateOrder([FromBody] EditOrderDto data)
        {
            try
            {
                var order = await _OrdersRepository.Exist(data.Id);
                if (!order)
                {
                    return NotFound("Order Not Found!");
                }
                var command = new EditOrderRequestCommand { OrderDto = data };
                var commandResponse = await _mediator.Send(command);
                return commandResponse.Success ? Ok(commandResponse) : StatusCode(400, commandResponse);

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("Delete/{deleteId}")]
        public async Task<ActionResult>
       DeleteOrder(int deleteId)
        {
            try
            {
                var order = await _OrdersRepository.Exist(deleteId);
                if (!order)
                {
                    return NotFound("Order Not Found!");
                }
                try
                {
                    var command = new DeleteOrderRequestCommand { Id = deleteId };
                    await _mediator.Send(command);
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex}");
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion
    }
}
