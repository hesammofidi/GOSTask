using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SRPDtos;
using Application.Dtos.SystemPermissionDtos;
using Application.Dtos.SystemRoleDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using System.Text.Json;
using static Application.Features.SRPFeatures.Command.SRPRequestsHandlesCommand;
using static Application.Features.SRPFeatures.Query.SRPRequestsHandlesQuery;
using static Application.Features.SystemPermissionFeatures.Command.SPRequestsHandlersCommad;
using static Application.Features.SystemPermissionFeatures.Query.SPRequestsHandlersQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    public class SRPController : ApiController
    {
        private readonly ISystemsRolesPermissionRepository _SRPRepository;
        private readonly IMediator _mediator;
        public SRPController(ISystemsRolesPermissionRepository sRPRepository, IMediator mediator)
        {
            _SRPRepository = sRPRepository;
            _mediator = mediator;
        }

        #region FilterSearch
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<SRPInfoDto>>> FilterSRPAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new SRPFilterQueryRequest { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SRPInfoDto>>> SearchSRPAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new SRpSerchQueryRequest { SearchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        public async Task<ActionResult<SRPInfoDto>> GetSRPByIdAsync([FromRoute] int id)
        {
            var SRP = await _SRPRepository.Exist(id);

            if (!SRP)
            {
                return NotFound($"Invalid SRPId : {id}");
            }

            var sPDto = await _mediator.Send(new GetSRPRequestQuery { SRPId = id });

            return Ok(sPDto);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddSRP
         ([FromBody] AddSRPDto data)
        {
            var command = new AddSRPRequestCommand { addSrpDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateSRP([FromBody] EditSRPDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("SRPId is Null");
            }
            var user = await _SRPRepository.Exist(data.Id);
            if (!user)
            {
                return NotFound("SystemPermission Not Found!");
            }
            var command = new EditSRPRequestCommand { editSrpDto = data };
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
                return BadRequest("systemId is Null");
            }
            var user = await _SRPRepository.Exist(deleteId);
            if (user == null)
            {
                return NotFound("SRP Not Found!");
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
