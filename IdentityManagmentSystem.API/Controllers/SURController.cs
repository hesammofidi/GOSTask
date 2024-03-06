using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SRPDtos;
using Application.Dtos.SURDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using System.Text.Json;
using static Application.Features.SRPFeatures.Command.SRPRequestsHandlesCommand;
using static Application.Features.SRPFeatures.Query.SRPRequestsHandlesQuery;
using static Application.Features.SURFeatures.Commands.SURRequestsHandlersCommand;
using static Application.Features.SURFeatures.Queries.SURRequestHandlerQuery;
using static Application.Features.SystemPermissionFeatures.Command.SPRequestsHandlersCommad;

namespace IdentityManagmentSystem.API.Controllers
{
 

    public class SURController : ApiController
    {
        private readonly ISystemsRoleUsersRepository _SURRepository;
        private readonly IMediator _mediator;
        public SURController(
            ISystemsRoleUsersRepository sURRepository, 
            IMediator mediator)
        {
            _SURRepository = sURRepository;
            _mediator = mediator;
        }
        #region FilterSearch
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<SURInfoDto>>> FilterSURAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new SURFilterQueryRequest { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SURInfoDto>>> SearchSURAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new SURSerchQueryRequest { SearchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        public async Task<ActionResult<SURInfoDto>> GetSURByIdAsync([FromRoute] int id)
        {
            var SUR = await _SURRepository.Exist(id);

            if (!SUR)
            {
                return NotFound($"Invalid SRPId : {id}");
            }

            var surDto = await _mediator.Send(new GetSURRequestQuery { SURId = id });

            return Ok(surDto);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddSUR
         ([FromBody] AddSURDto data)
        {
            var command = new AddSURRequestCommand { addSurdto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateSUR([FromBody] EditSURDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("SRPId is Null");
            }
            var user = await _SURRepository.Exist(data.Id);
            if (!user)
            {
                return NotFound("SystemPermission Not Found!");
            }
            var command = new EditSURRequestCommand { editSURDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public async Task<ActionResult>
       DeleteSRP([FromBody] int deleteId)
        {
            if (deleteId == null)
            {
                return BadRequest("SURId is Null");
            }
            var user = await _SURRepository.Exist(deleteId);
            if (user == null)
            {
                return NotFound("SUR Not Found!");
            }
            try
            {
                var command = new DeleteSURRequestCommand { Id = deleteId };
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
