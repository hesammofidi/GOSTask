using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.SURPDtos;
using Application.Dtos.SURPDtos.Validators;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.SURPFeatures.Command
{
    public class SURPRequestsHandlersCommand
    {
        #region Add
        public class AddSURPRequestCommand : IRequest<BaseCommandResponse>
        {
            public AddSURPDto addSurpdto { get; set; }
        }

        public class AddSURPHandlerCommand : IRequestHandler<AddSURPRequestCommand, BaseCommandResponse>
        {
            private readonly ISystemsRolePermissionUsersRepository _SURPRepository;
            private readonly IMapper _mapper;

            public AddSURPHandlerCommand(

                IMapper mapper, ISystemsRolePermissionUsersRepository sURPRepository)
            {

                _mapper = mapper;
                _SURPRepository = sURPRepository;
            }
            public async Task<BaseCommandResponse> Handle(AddSURPRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddSURPValidator(_SURPRepository);
                var validationResult = await validator.ValidateAsync(request.addSurpdto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var surInfo = _mapper.Map<SystemUserRolePermission>(request.addSurpdto);
                    await _SURPRepository.AddAsync(surInfo);
                    response.Success = true;
                    response.Message = "Creation Successful";
                }
                return response;
            }
        }

        #endregion

        #region Edit
        public class EditSURPRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditSURPDto editSURPDto { get; set; }
        }

        public class EditSURPHandlerCommand : IRequestHandler<EditSURPRequestCommand, BaseCommandResponse>
        {
            private readonly ISystemsRolePermissionUsersRepository _SURPRepository;
            private readonly IMapper _mapper;

            public EditSURPHandlerCommand(
                IMapper mapper, ISystemsRolePermissionUsersRepository sURPRepository)
            {

                _mapper = mapper;
                _SURPRepository = sURPRepository;
            }
            public async Task<BaseCommandResponse> Handle(EditSURPRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditSURPValidator(_SURPRepository);
                var validationResult = await validator.ValidateAsync(request.editSURPDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Edit Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var surInfo = await _SURPRepository.GetByIdAsync(request.editSURPDto.Id);
                    _mapper.Map(surInfo, request.editSURPDto);
                    await _SURPRepository.UpdateAsync(surInfo);
                    response.Success = true;
                    response.Message = "Edit Successful";
                }
                return response;
            }
        }
        #endregion

        #region DeleteSRp
        public class DeleteSURPRequestCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteSURPHandlerCommand : IRequestHandler<DeleteSURPRequestCommand>
        {
            private readonly ISystemsRolePermissionUsersRepository _SURPRepository;
            public DeleteSURPHandlerCommand(ISystemsRolePermissionUsersRepository sURPRepository)
            {
                
                _SURPRepository = sURPRepository;
            }

            public async Task Handle(DeleteSURPRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _SURPRepository.GetByIdAsync(request.Id);
                await _SURPRepository.DeleteAsync(entity);
            }
        }
        #endregion
    }
}
