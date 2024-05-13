using Application.Contract.Persistance.EFCore;
using Application.Dtos.PeopleDtos;
using Application.Dtos.ProductDtos;
using Application.Responses;
using IdentityManagmentSystem.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;
using static Application.Features.PeopleFeatures.Command.PeopleRequestsHandlersCommad;
using static Application.Features.PeopleFeatures.Query.PeopleRequestsHandlersQuery;
using static Application.Features.ProductFeatures.Queries.GetProductsRequestHandlerQuery;

namespace IdentityManagmentSystem.API.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IPeopleRepository _peopleRepository;
        private readonly ILogger<PeopleController> _logger;
        public PeopleController(IMediator mediator,
                                          IPeopleRepository peopleRepository,
                                          ILogger<PeopleController> logger)
        {
            _mediator = mediator;
            _peopleRepository = peopleRepository;
            _logger = logger;
        }
        #region GetAllWithDapper
        [HttpGet("GetAllDapper")]
        public async Task<ActionResult<IEnumerable<PeopleDto>>> GetAllPeopleAsync()
        {
            try
            {
                var query = new GetAllPeopleRequestQuery { };
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion

        #region getbyId
        [HttpGet("{id}")]
        public async Task<ActionResult<PeopleDto>> GetPeopleByIdAsync([FromRoute] int id)
        {
            try
            {

                var Product = await _peopleRepository.Exist(id);

                if (!Product)
                {
                    return NotFound($"Invalid PeopleId : {id}");
                }

                var people = await _mediator.Send(new GetPeopleRequestQuery { PeopleId = id });

                return Ok(people);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public async Task<ActionResult<BaseCommandResponse>> AddPeople
         ([FromBody] AddPeopleDto data)
        {
            try
            {

                var command = new AddPeopleRequestCommand { addSpDto = data };
                var commandResponse = await _mediator.Send(command);
                return commandResponse.Success ? Ok(commandResponse) : StatusCode(400, commandResponse);

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion

        #region Edit
        [HttpPut("Edit")]
        public async Task<ActionResult<BaseCommandResponse>>
          UpdateSP([FromBody] EditPeopleDto data)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("Delete/{deleteId}")]
        public async Task<ActionResult>
       DeleteSP(int deleteId)
        {
            try
            {
                var person = await _peopleRepository.Exist(deleteId);
                if (!person)
                {
                    return NotFound("person Not Found!");
                }
                var command = new DeletePeopleRequestCommand { Id = deleteId };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                return StatusCode(500);
            }

        }
        #endregion
    }
}
