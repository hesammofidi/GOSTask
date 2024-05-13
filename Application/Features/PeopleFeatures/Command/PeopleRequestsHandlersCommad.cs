using Application.Contract.Persistance.EFCore;
using Application.Dtos.PeopleDtos;
using Application.Dtos.PeopleDtos.Validators;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PeopleFeatures.Command
{
    public class PeopleRequestsHandlersCommad
    {
        #region Add
        public class AddPeopleRequestCommand : IRequest<BaseCommandResponse>
        {
            public AddPeopleDto? addSpDto { get; set; }
        }
        public class AddPeopleHandlerCommand : IRequestHandler<AddPeopleRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPeopleRepository _peopleRepository;
            public AddPeopleHandlerCommand(IMapper mapper, IPeopleRepository peopleRepository)
            {
                _mapper = mapper;
                _peopleRepository = peopleRepository;
            }

            public async Task<BaseCommandResponse> Handle(AddPeopleRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddPeopleValidator();
                var validationResult = await validator.ValidateAsync(request.addSpDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var spInfo = _mapper.Map<People>(request.addSpDto);
                    await _peopleRepository.AddAsync(spInfo);
                    response.Success = true;
                    response.Message = "Creation Successful";
                }
                return response;
            }
        }
        #endregion

        #region Edit
        public class EditPeopleRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditPeopleDto? editSpDto { get; set; }
        }
        public class EditPeopleHandlerCommand : IRequestHandler<EditPeopleRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPeopleRepository _peopleRepository;
            public EditPeopleHandlerCommand(IMapper mapper, IPeopleRepository peopleRepository)
            {
                _mapper = mapper;
                _peopleRepository = peopleRepository;
            }

            public async Task<BaseCommandResponse> Handle(EditPeopleRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditPeopleValidator();
                var validationResult = await validator.ValidateAsync(request.editSpDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Edit Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var PeopleInfo = await _peopleRepository.GetByIdAsync(request.editSpDto.Id);
                    _mapper.Map( request.editSpDto, PeopleInfo);
                    await _peopleRepository.UpdateAsync(PeopleInfo);
                    response.Success = true;
                    response.Message = "Edit Successful";
                }
                return response;
            }
        }
        #endregion

        #region Delete
        public class DeletePeopleRequestCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeletePeopleHandlerCommand : IRequestHandler<DeletePeopleRequestCommand>
        {
            private readonly IPeopleRepository _peopleRepository;
            public DeletePeopleHandlerCommand(IPeopleRepository peopleRepository)
            {
                _peopleRepository = peopleRepository;
            }

            public async Task Handle(DeletePeopleRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _peopleRepository.GetByIdAsync(request.Id);
                await _peopleRepository.DeleteAsync(entity);
            }
        }
        #endregion
    }
}
