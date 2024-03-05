using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SystemPermissionDtos;
using Application.Dtos.SystemRoleDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Application.Features.SystemPermissionFeatures.Command.SPRequestsHandlersCommad;
using static Application.Features.SystemPermissionFeatures.Query.SPRequestsHandlersQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    public class SystemPermissionController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly ISystemsPermissionsRepository _systemPermissionRepository;
        public SystemPermissionController(IMediator mediator, 
                                          ISystemsPermissionsRepository systemPermissionRepository)
        {
            _mediator = mediator;
            _systemPermissionRepository = systemPermissionRepository;
        }
        #region FilterSearch
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<SystemPermissionDto>>> FilterSPAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new SPFilterQueryRequest { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SystemPermissionDto>>> SearchSPAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new SpSerchQueryRequest { SearchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemRoleDto>> GetSPByIdAsync([FromRoute] int id)
        {
            var SP = await _systemPermissionRepository.Exist(id);

            if (!SP)
            {
                return NotFound($"Invalid PermissionId : {id}");
            }

            var sPDto = await _mediator.Send(new GetSPRequestQuery { SPId = id });

            return Ok(sPDto);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddSP
         ([FromBody] AddSPDto data)
        {
            var command = new AddSpRequestCommand { addSpDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateSP([FromBody] EditSPDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("SPId is Null");
            }
            var user = await _systemPermissionRepository.Exist(data.Id);
            if (!user)
            {
                return NotFound("SystemPermission Not Found!");
            }
            var command = new EditSPRequestCommand { editSpDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<ActionResult>
       DeleteSP([FromBody] int deleteId)
        {
            if (deleteId == null)
            {
                return BadRequest("systemId is Null");
            }
            var user = await _systemPermissionRepository.Exist(deleteId);
            if (user == null)
            {
                return NotFound("system Not Found!");
            }
            try
            {
                var command = new DeleteSPRequestCommand { Id = deleteId };
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
