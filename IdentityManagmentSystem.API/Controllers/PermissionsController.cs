using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.ProductDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Application.Features.PermissionFeatures.Commands.AddProductRequestHandlerCommand;
using static Application.Features.PermissionFeatures.Commands.DeletePermissionRequestHandlerCommand;
using static Application.Features.PermissionFeatures.Commands.EditPermissionRequestHandlerCommand;
using static Application.Features.PermissionFeatures.Queries.GetPermissionsRequestHandlerQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    public class PermissionsController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IProductsRepository _ProductsRepository;
        public PermissionsController(IMediator mediator, 
            IProductsRepository ProductsRepository)
        {
            _mediator = mediator;
            _ProductsRepository = ProductsRepository;
        }

        #region FilterSearch
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<ProductInfoDto>>> FilterPermissionsAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new GetPermissionFilterRequestQuery { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductInfoDto>>> SearchPermissionsAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new GetPermissionSearchRequestQuery { searchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInfoDto>> GetPermissionByIdAsync([FromRoute] int id)
        {
            var permission = await _ProductsRepository.Exist(id);

            if (!permission)
            {
                return NotFound($"Invalid PermissionId : {id}");
            }

            var permissionDto = await _mediator.Send(new GetPermissionRequestQuery { permissionId = id });

            return Ok(permissionDto);
        }
        #endregion

        #region Addpermission
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddPermission
         ([FromBody] AddProductDto data)
        {
            var command = new AddProductRequestCommand { permissionDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region EditPermission
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdatePermission([FromBody] EditProductDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("permissionId is Null");
            }
            var user = await _ProductsRepository.Exist(data.Id);
            if (!user)
            {
                return NotFound("permission Not Found!");
            }
            var command = new EditPermissionRequestCommand { permissionDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Deletepermission
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult>
       Deletepermission( int id)
        {
            if ( id == null)
            {
                return BadRequest("permissionId is Null");
            }
            var user = await _ProductsRepository.Exist( id);
            if (user == null)
            {
                return NotFound("permission Not Found!");
            }
            try
            {
                var command = new DeletePermissionRequestCommand { permissionId = id };
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
