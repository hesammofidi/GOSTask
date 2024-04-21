using Application.Constants;
using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SURPDtos;
using Application.Responses;
using Domain.Users;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using static Application.Features.SURPFeatures.Command.SURPRequestsHandlersCommand;
using static Application.Features.SURPFeatures.Handler.SURPRequestHandlerQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    public class SURPController : ApiController
    {
        private readonly ISystemsRepository _systemrepos;
        private readonly IPermissionsRepository _permRepos;
        private readonly ISystemsRolePermissionUsersRepository _srupRepos;
        private readonly UserManager<DomainUser> _usermanager;
        private readonly IMediator _mediator;
        public SURPController
            (ISystemsRepository systemrepos,
            UserManager<DomainUser> usermanager,
            IMediator mediator,
            IPermissionsRepository permRepos)
        {
            _systemrepos = systemrepos;
            _usermanager = usermanager;
            _mediator = mediator;
            _permRepos = permRepos;
        }
        #region ExistPermission
        [HttpPost("ExistPermission")]
        [Authorize]
        public async Task<ActionResult<bool>> ExistUserPermission(
          [FromBody] string permissionName)
        {
            string token = Request.Headers["Authorization"].ToString().Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            string systemId = jwtToken.Claims.First(claim => claim.Type == CustomClaimTypes.System).Value;
            string userId = jwtToken.Claims.First(claim => claim.Type == CustomClaimTypes.Uid).Value;

            //var CheckSystem = await _systemrepos.Exist(int.Parse(systemId));
            //var CheckUser = await _usermanager.FindByIdAsync(userId);
            //var checkPermis = await _permRepos.ExistTitle(data.PermissionName);
            if(permissionName == null || systemId == null || userId == null)
            {
                return NotFound(false);
            }
            else
            {
                var query = new ExistPermissionRequest
                { 
                    PermisName = permissionName, 
                    Uid=userId,
                    Sid= int.Parse(systemId) 
                };
                var response = await _mediator.Send(query);
                return Ok(response);
            }

        }
        #endregion

        #region FilterSearch
        [HttpGet("filter")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SURPInfoDto>>> FilterSURPAsync(
        [FromQuery] FilterDataDto data)
        {
            var query = new SURPFilterQueryRequest { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SURPInfoDto>>> SearchSURPAsync(
          [FromQuery] SearchDataDto data)
        {
            var query = new SURPSerchQueryRequest { SearchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<SURPInfoDto>> GetSURPByIdAsync([FromRoute] int id)
        {
            var SURP = await _srupRepos.Exist(id);

            if (!SURP)
            {
                return NotFound($"Invalid SURPId : {id}");
            }

            var surpDto = await _mediator.Send(new GetSURPRequestQuery { SURPId = id });

            return Ok(surpDto);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> AddSURP
         ([FromBody] AddSURPDto data)
        {
            var command = new AddSURPRequestCommand { addSurpdto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateSURP([FromBody] EditSURPDto data)
        {
            if (data.Id == null)
            {
                return BadRequest("SRPId is Null");
            }
            var user = await _srupRepos.Exist(data.Id);
            if (!user)
            {
                return NotFound("SystemPermission Not Found!");
            }
            var command = new EditSURPRequestCommand { editSURPDto = data };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete/{deleteId}")]
        [Authorize]
        public async Task<ActionResult>
       DeleteSRP( int deleteId)
        {
            if (deleteId == null)
            {
                return BadRequest("SURId is Null");
            }
            var user = await _srupRepos.Exist(deleteId);
            if (user == null)
            {
                return NotFound("SUR Not Found!");
            }
            try
            {
                var command = new DeleteSURPRequestCommand { Id = deleteId };
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
