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
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IMediator mediator,
            IProductsRepository ProductsRepository,
            ILogger<ProductsController> logger)
        {
            _mediator = mediator;
            _ProductsRepository = ProductsRepository;
            _logger = logger;
        }
        #region GetAllWithDapper
        [HttpGet("GetAllDapper")]
        public async Task<ActionResult<IEnumerable<ProductInfoDto>>> GetAllProductsAsync()
        {
            try
            {
                var query = new GetAllProductRequestQuery { };
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
            try
            {
                var Product = await _ProductsRepository.Exist(id);

                if (!Product)
                {
                    return NotFound($"Invalid ProductId : {id}");
                }

                var ProductDto = await _mediator.Send(new GetProductRequestQuery { ProductId = id });

                return Ok(ProductDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion

        #region AddProduct
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddProduct
         ([FromBody] AddProductDto data)
        {
            try
            {
                var command = new AddProductRequestCommand { ProductDto = data };
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

        #region EditProduct
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateProduct([FromBody] EditProductDto data)
        {
            try
            {
                var product = await _ProductsRepository.Exist(data.Id);
                if (!product)
                {
                    return NotFound("Product Not Found!");
                }
                var command = new EditProductRequestCommand { ProductDto = data };
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

        #region DeleteProduct
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult>
       DeleteProduct( int id)
        {
           
            try
            {
                var ExistItem = await _ProductsRepository.Exist(id);
                if (!ExistItem)
                {
                    return NotFound("Product Not Found!");
                }
                var command = new DeleteProductRequestCommand { ProductId = id };
                await _mediator.Send(command);
                return Ok();
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
