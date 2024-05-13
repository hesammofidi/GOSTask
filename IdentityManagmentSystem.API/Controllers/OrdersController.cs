using Application.Contract.Persistance.EFCore;
using Application.Dtos.OrderDtos;
using Application.Dtos.ProductDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
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
        public OrdersController(IMediator mediator,
            IOrdersRepository OrdersRepository)
        {
            _mediator = mediator;
            _OrdersRepository = OrdersRepository;
        }

        #region GetAllWithDapper
        [HttpGet("GetAllDapper")]
        public async Task<ActionResult<IEnumerable<OrderInfoDto>>> GetAllOrdersAsync()
        {
            var query = new GetAllOrdersRequestQuery { };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        #endregion

        #region getbyIdDapper
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderInfoDto>> GetOrderByIdAsync([FromRoute] int id)
        {
            var Product = await _OrdersRepository.Exist(id);

            if (!Product)
            {
                return NotFound($"Invalid OrderId : {id}");
            }

            var OrderDto = await _mediator.Send(new GetOrdersRequestQuery { OrderId = id });

            return Ok(OrderDto);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddOrder
         ([FromBody] AddOrderDto data)
        {
            var command = new AddOrderRequestCommand { OrderDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateOrder([FromBody] EditOrderDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("OrderId is Null");
            }
            var user = await _OrdersRepository.Exist(data.Id);
            if (!user)
            {
                return NotFound("Order Not Found!");
            }
            var command = new EditOrderRequestCommand { OrderDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<ActionResult>
       DeleteOrder([FromBody] int deleteId)
        {
            if (deleteId == null)
            {
                return BadRequest("OrderId is Null");
            }
            var user = await _OrdersRepository.Exist(deleteId);
            if (user == null)
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
                return BadRequest("Delete Request Fail");
            }

        }
        #endregion
    }
}
