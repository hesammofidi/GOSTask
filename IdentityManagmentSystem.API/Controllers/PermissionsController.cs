using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.PermissionsDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Application.Features.PermissionFeatures.Commands.AddPermissionRequestHandlerCommand;
using static Application.Features.PermissionFeatures.Commands.DeletePermissionRequestHandlerCommand;
using static Application.Features.PermissionFeatures.Commands.EditPermissionRequestHandlerCommand;
using static Application.Features.PermissionFeatures.Queries.GetPermissionsRequestHandlerQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    public class PermissionsController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IPermissionsRepository _permissionRepository;
        public PermissionsController(IMediator mediator, 
            IPermissionsRepository permissionRepository)
        {
            _mediator = mediator;
            _permissionRepository = permissionRepository;
        }

        #region FilterSearch
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<PermissionInfoDto>>> FilterPermissionsAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new GetPermissionFilterRequestQuery { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PermissionInfoDto>>> SearchPermissionsAsync(
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
        public async Task<ActionResult<PermissionInfoDto>> GetPermissionByIdAsync([FromRoute] int id)
        {
            var permission = await _permissionRepository.Exist(id);

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
         ([FromBody] AddPermissionDto data)
        {
            var command = new AddPermissionRequestCommand { permissionDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region EditPermission
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdatePermission([FromBody] EditPermissionDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("permissionId is Null");
            }
            var user = await _permissionRepository.Exist(data.Id);
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
            var user = await _permissionRepository.Exist( id);
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
