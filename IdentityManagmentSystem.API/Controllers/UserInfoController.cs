using Application.Dtos.CommonDtos;
using Application.Models.IdentityModels.UserModels;
using Application.Responses;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Application.Features.UserFeatures.Commands.AddUserRequestHandlerCommand;
using static Application.Features.UserFeatures.Commands.ChangePasswordByAdminRequestHandlerCommand;
using static Application.Features.UserFeatures.Commands.EditUserRequestHandlerCommand;
using static Application.Features.UserFeatures.Queries.UsersFilterItemsRequestHandlerQuery;
using static Application.Features.UserFeatures.Queries.UsersSearchItemsRequestHandlerQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<DomainUser> _usermanager;
        public UserInfoController(IMediator mediator, UserManager<DomainUser> usermanager)
        {
            _mediator = mediator;
            _usermanager = usermanager;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<BaseCommandResponse>> RegisterUse
            ([FromBody] RegistrationRequest addUserDto)
        {
            var command = new AddUserRequestCommand { AddOrRegisterUserDto = addUserDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        #region EditUser
        [HttpPut("EditUser")]
        public async Task<ActionResult<BaseCommandResponse>>
            UpdateUser([FromBody] EditUserDto editUserInfoDto)
        {
            if (editUserInfoDto.UserId == null)
            {
                return BadRequest("UserId is Null");
            }
            var user = await _usermanager.FindByIdAsync(editUserInfoDto.UserId);
            if (user == null)
            {
                return NotFound("User Not Found!");
            }
            var command = new EditUserRequestCommand { editUserDto = editUserInfoDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region ChangePAssword
        [HttpPut("ChangePassword")]
        public async Task<ActionResult<BaseCommandResponse>>
            ChangePasswordByAdmin([FromBody] ChangePasswordDto changePassword)
        {
            if (changePassword.UserId == null)
            {
                return BadRequest("UserId is Null");
            }
            var user = await _usermanager.FindByIdAsync(changePassword.UserId);
            if (user == null)
            {
                return NotFound("User Not Found!");
            }
            var command = new ChangePasswordRequestCommand { changePasswordDto = changePassword };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        #endregion

        #region GetFilterdUser
        [HttpGet("FilterUser")]
        public async Task<ActionResult<IEnumerable<UserInfoDto>>> FilterUsersAsync(
            [FromQuery] FilterDataDto data)
        {
            var query = new UsersFilterItemsRequestQuery { FilterDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion

        #region SearchUser
        [HttpGet("SearchUser")]
        public async Task<ActionResult<IEnumerable<UserInfoDto>>> SearchUsersAsync(
            [FromQuery] SearchDataDto data)
        {
            var query = new UsersSearchItemsRequestQuery { SearchDataDto = data };
            var response = await _mediator.Send(query);
            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(response.Paging));

            return Ok(response.Items);
        }
        #endregion
    }
}
