using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.OrderProductDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Application.Features.OrderProduFeatures.Commands.OrderProductCommandsRequestsHandlers;
using static Application.Features.OrderProduFeatures.Query.OrderProductQueryRequestsHandlers;

namespace IdentityManagmentSystem.API.Controllers
{
    public class OrderProductController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderProductController(IMediator mediator, IOrderProductRepository orderProductRepository)
        {
            _mediator = mediator;
            _orderProductRepository = orderProductRepository;
        }
        #region FilterSearch
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<OrderProductDto>>> FilterSRAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new OrderProductFilterQueryRequest { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<OrderProductDto>>> SearchSRAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new OrderProductSerchQueryRequest { SearchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderProductDto>> GetSRByIdAsync([FromRoute] int id)
        {
            var OrderProduct = await _orderProductRepository.Exist(id);

            if (!OrderProduct)
            {
                return NotFound($"Invalid Id : {id}");
            }

            var OrderProductDto = await _mediator.Send(new GetOrderProductRequestQuery { SRId = id });

            return Ok(OrderProductDto);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddOrderProduct
         ([FromBody] AddOrderProductDto data)
        {
            var command = new AddOrderProductRequestCommand { addSRDto = data };
            var commandResponse = await _mediator.Send(command);
            return commandResponse.Success ? Ok(commandResponse) : StatusCode(400, commandResponse);
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateOrderProduct([FromBody] EditOrderProductDto data)
        {
            var command = new EditOrderProductRequestCommand { ediSRDto = data };
            var commandResponse = await _mediator.Send(command);
            return commandResponse.Success ? Ok(commandResponse) : StatusCode(400, commandResponse);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete/{deleteId}")]
        public async Task<ActionResult>
       DeleteOrderProduct(int deleteId)
        {
           
            var entity = await _orderProductRepository.Exist(deleteId);
            if (!entity)
            {
                return NotFound("OP Not Found!");
            }
            try
            {
                var command = new DeleteOrderProductRequestCommand { Id = deleteId };
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
