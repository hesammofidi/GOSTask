using Application.Contract.Persistance.EFCore;
using Application.Dtos.CommonDtos;
using Application.Dtos.ProductDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Application.Features.ProductFeatures.Commands.AddProductRequestHandlerCommand;
using static Application.Features.ProductFeatures.Commands.DeleteProductRequestHandlerCommand;
using static Application.Features.ProductFeatures.Commands.EditProductRequestHandlerCommand;
using static Application.Features.ProductFeatures.Queries.GetProductsRequestHandlerQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IProductsRepository _ProductsRepository;
        public ProductsController(IMediator mediator,
            IProductsRepository ProductsRepository)
        {
            _mediator = mediator;
            _ProductsRepository = ProductsRepository;
        }
        #region GetAllWithDapper
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProductInfoDto>>> GetAllProductsAsync()
        {
            var query = new GetAllProductRequestQuery { };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        #endregion 

        #region FilterSearch
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<ProductInfoDto>>> FilterProductsAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new GetProductFilterRequestQuery { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductInfoDto>>> SearchProductsAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new GetProductSearchRequestQuery { searchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInfoDto>> GetProductByIdAsync([FromRoute] int id)
        {
            var Product = await _ProductsRepository.Exist(id);

            if (!Product)
            {
                return NotFound($"Invalid ProductId : {id}");
            }

            var ProductDto = await _mediator.Send(new GetProductRequestQuery { ProductId = id });

            return Ok(ProductDto);
        }
        #endregion

        #region AddProduct
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddProduct
         ([FromBody] AddProductDto data)
        {
            var command = new AddProductRequestCommand { ProductDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region EditProduct
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateProduct([FromBody] EditProductDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("ProductId is Null");
            }
            var user = await _ProductsRepository.Exist(data.Id);
            if (!user)
            {
                return NotFound("Product Not Found!");
            }
            var command = new EditProductRequestCommand { ProductDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region DeleteProduct
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult>
       DeleteProduct( int id)
        {
            if ( id == null)
            {
                return BadRequest("ProductId is Null");
            }
            var user = await _ProductsRepository.Exist( id);
            if (user == null)
            {
                return NotFound("Product Not Found!");
            }
            try
            {
                var command = new DeleteProductRequestCommand { ProductId = id };
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
