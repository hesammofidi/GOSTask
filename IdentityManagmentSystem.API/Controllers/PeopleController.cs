using Application.Contract.Persistance.EFCore;
using Application.Dtos.PeopleDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.PeopleFeatures.Command.PeopleRequestsHandlersCommad;

namespace IdentityManagmentSystem.API.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IPeopleRepository _peopleRepository;
        public PeopleController(IMediator mediator, 
                                          IPeopleRepository peopleRepository)
        {
            _mediator = mediator;
            _peopleRepository = peopleRepository;
        }
  
        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddSP
         ([FromBody] AddPeopleDto data)
        {
           
                var command = new AddPeopleRequestCommand { addSpDto = data };
                var commandResponse = await _mediator.Send(command);
                return commandResponse.Success ? Ok(commandResponse) : StatusCode(400, commandResponse);
          
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateSP([FromBody] EditPeopleDto data)
        {
            var user = await _peopleRepository.Exist(data.Id);
            if (!user)
            {
                return NotFound("person Not Found!");
            }
            var command = new EditPeopleRequestCommand { editSpDto = data };
            var commandResponse = await _mediator.Send(command);
            return commandResponse.Success ? Ok(commandResponse) : StatusCode(400, commandResponse);
        }
        #endregion

        #region Delete
        [HttpDelete("Delete/{deleteId}")]
        public async Task<ActionResult>
       DeleteSP(int deleteId)
        {
            var person = await _peopleRepository.Exist(deleteId);
            if (!person)
            {
                return NotFound("person Not Found!");
            }
            try
            {
                var command = new DeletePeopleRequestCommand { Id = deleteId };
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
