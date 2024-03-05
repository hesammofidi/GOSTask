using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SystemsDto;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Application.Features.SystemFeatures.Commands.SystemRequestsHandlersCommand;
using static Application.Features.SystemFeatures.Queries.GetSystemsRequestHandlerQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    public class SystemsController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly ISystemsRepository _systemsRepository;
        public SystemsController(IMediator mediator,
            ISystemsRepository systemsRepository)
        {
            _mediator = mediator;
            _systemsRepository = systemsRepository;
        }

        #region FilterSearch
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<SystemInfoDto>>> FilterSystemsAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new GetSystemsFilterRequestQuery { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SystemInfoDto>>> SearchSystemsAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new GetSystemsSearchRequestQuery { searchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemInfoDto>> GetSystemByIdAsync([FromRoute] int id)
        {
            var system = await _systemsRepository.Exist(id);

            if (!system)
            {
                return NotFound($"Invalid PermissionId : {id}");
            }

            var systemDto = await _mediator.Send(new GetSystemsRequestQuery { systemId = id });

            return Ok(systemDto);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddSystem
         ([FromBody] SystemInfoDto data)
        {
            var command = new AddSystemRequestCommand { systemDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateSystem([FromBody] SystemInfoDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("systemId is Null");
            }
            var user = await _systemsRepository.Exist(data.Id);
            if (!user)
            {
                return NotFound("System Not Found!");
            }
            var command = new EditSystemRequestCommand { systemDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<ActionResult>
       DeleteSystem([FromBody] int deleteId)
        {
            if (deleteId == null)
            {
                return BadRequest("systemId is Null");
            }
            var user = await _systemsRepository.Exist(deleteId);
            if (user == null)
            {
                return NotFound("system Not Found!");
            }
            try
            {
                var command = new DeleteSystemRequestCommand { Id = deleteId };
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
