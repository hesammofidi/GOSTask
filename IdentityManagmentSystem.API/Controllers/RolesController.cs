using Application.Dtos.CommonDtos;
using Application.Dtos.RoleDtos;
using Application.Responses;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Application.Features.RoleFeatures.Commands.AddRolesRequestHandlerCommand;
using static Application.Features.RoleFeatures.Commands.DeleteRoleRequestHandlerCommand;
using static Application.Features.RoleFeatures.Commands.EditRolesRequestHandlerCommand;
using static Application.Features.RoleFeatures.Queries.RolesFilterItemsRequestHandlerQuery;
using static Application.Features.RoleFeatures.Queries.RolesSearchItemsRequestHandlerQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly RoleManager<Roles> _roleManager;

        public RolesController(IMediator mediator, RoleManager<Roles> roleManager)
        {
            _mediator = mediator;
            _roleManager = roleManager;
        }

        [HttpPost("AddRoles")]
        public async Task<ActionResult<BaseCommandResponse>> AddRole
          ([FromBody] AddRoleDto data)
        {
            var command = new AddRolesRequestCommand { addRoleDto = data };
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        #region Edit
        [HttpPut("EditRole")]
        public async Task<ActionResult<BaseCommandResponse>>
            UpdateRole([FromBody] EditRoleDto editroledata)
        {
            if (editroledata.Id == null)
            {
                return BadRequest("RoleId is Null");
            }
            var user = await _roleManager.FindByIdAsync(editroledata.Id);
            if (user == null)
            {
                return NotFound("Role Not Found!");
            }
            var command = new EditRolesRequestCommand { EditRoleDto = editroledata };
            var response = await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        #endregion

        #region GetFilterAndSearchdroles
        [HttpGet("FilterRoles")]
        public async Task<ActionResult<IEnumerable<RoleInfoDto>>> FilterRolesAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new RolesFilterItemsRequestQuery { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("SearchRoles")]
        public async Task<ActionResult<IEnumerable<RoleInfoDto>>> SearchRolesAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new RolesSearchItemsRequestQuery { searchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        [HttpDelete("DeleteRole/{deleteRoleId}")]
        public async Task<ActionResult>
            DeleteRole(string deleteRoleId)
        {
            if (deleteRoleId == null)
            {
                return BadRequest("RoleId is Null");
            }
            var user = await _roleManager.FindByIdAsync(deleteRoleId);
            if (user == null)
            {
                return NotFound("User Not Found!");
            }
            try
            {
                var command = new DeleteRoleRequestCommand { RoleId = deleteRoleId };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Delete Request Fail");
            }
           
        }
    }
}
