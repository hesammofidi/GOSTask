using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SystemRoleDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Application.Features.SystemRoleFeatures.Commands.SRCommandsRequestsHandlers;
using static Application.Features.SystemRoleFeatures.Query.SRQueryRequestsHandlers;

namespace IdentityManagmentSystem.API.Controllers
{
    public class SystemRoleController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IOrderProductRepository _systemRoleRepository;
        public SystemRoleController(IMediator mediator, IOrderProductRepository systemRoleRepository)
        {
            _mediator = mediator;
            _systemRoleRepository = systemRoleRepository;
        }
        #region FilterSearch
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<SystemRoleDto>>> FilterSRAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new SRFilterQueryRequest { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SystemRoleDto>>> SearchSRAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new SRSerchQueryRequest { SearchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemRoleDto>> GetSRByIdAsync([FromRoute] int id)
        {
            var systemRole = await _systemRoleRepository.Exist(id);

            if (!systemRole)
            {
                return NotFound($"Invalid PermissionId : {id}");
            }

            var systemroleDto = await _mediator.Send(new GetSRRequestQuery { SRId = id });

            return Ok(systemroleDto);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddSystemRole
         ([FromBody] AddSystemRoleDto data)
        {
            var command = new AddSRRequestCommand { addSRDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateSystemROle([FromBody] EditSystemRoelDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("systemRoleId is Null");
            }
            var user = await _systemRoleRepository.Exist(data.Id);
            if (!user)
            {
                return NotFound("Systemrole Not Found!");
            }
            var command = new EditSRRequestCommand { ediSRDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete/{deleteId}")]
        public async Task<ActionResult>
       DeleteSystemrole(int deleteId)
        {
            if (deleteId == null)
            {
                return BadRequest("systemId is Null");
            }
            var user = await _systemRoleRepository.Exist(deleteId);
            if (user == null)
            {
                return NotFound("system Not Found!");
            }
            try
            {
                var command = new DeleteSRRequestCommand { Id = deleteId };
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
