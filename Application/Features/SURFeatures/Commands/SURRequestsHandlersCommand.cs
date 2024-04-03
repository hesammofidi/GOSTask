using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.SURDtos;
using Application.Dtos.SURDtos.Validators;
using Application.Dtos.SURPDtos;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using static Application.Features.SRPFeatures.Query.SRPRequestsHandlesQuery;
using static Application.Features.SURPFeatures.Command.SURPRequestsHandlersCommand;

namespace Application.Features.SURFeatures.Commands
{
    public class SURRequestsHandlersCommand
    {
        #region Add
        public class AddSURRequestCommand : IRequest<BaseCommandResponse>
        {
            public AddSURDto addSurdto { get; set; }
        }

        public class AddSURHandlerCommand : IRequestHandler<AddSURRequestCommand, BaseCommandResponse>
        {
            private readonly ISystemsRoleUsersRepository _SURRepository;
            private readonly ISystemsRolesPermissionRepository _SRPRepository;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;

            public AddSURHandlerCommand(

                IMapper mapper,
                ISystemsRoleUsersRepository sURRepository,
                ISystemsRolesPermissionRepository sRPRepository,
                IMediator mediator)
            {

                _mapper = mapper;
                _SURRepository = sURRepository;
                _SRPRepository = sRPRepository;
                _mediator = mediator;
            }
            public async Task<BaseCommandResponse> Handle(AddSURRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddSURValidator(_SURRepository);
                var validationResult = await validator.ValidateAsync(request.addSurdto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    
                    var surInfo = _mapper.Map<SystemRoleUser>(request.addSurdto);
                    var getPermissionsCommand = new GetPermissionsRequestCommand
                    { 
                        SystemId = surInfo.systemId, 
                        RoleId = surInfo.RoleId 
                    };
                    var srpList = await _mediator.Send(getPermissionsCommand);
                    await _SURRepository.AddAsync(surInfo);
                    foreach (var permissionId in srpList)
                    {
                        var addSURPCommand = new AddSURPRequestCommand
                        {
                            addSurpdto = new AddSURPDto
                            {
                                systemId = surInfo.systemId,
                                usersId = surInfo.usersId,
                                PermissionId = permissionId,
                                RoleId = surInfo.RoleId
                            }
                        };
                        await _mediator.Send(addSURPCommand);
                    }
                    response.Success = true;
                    response.Message = "Creation Successful";
                }
                return response;
            }
        }

        #endregion

        #region Edit
        public class EditSURRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditSURDto editSURDto { get; set; }
        }

        public class EditSURHandlerCommand : IRequestHandler<EditSURRequestCommand, BaseCommandResponse>
        {
            private readonly ISystemsRoleUsersRepository _SURRepository;
            private readonly IMapper _mapper;

            public EditSURHandlerCommand(
                IMapper mapper, ISystemsRoleUsersRepository sURRepository)
            {

                _mapper = mapper;
                _SURRepository = sURRepository;
            }
            public async Task<BaseCommandResponse> Handle(EditSURRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditSURValidator(_SURRepository);
                var validationResult = await validator.ValidateAsync(request.editSURDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Edit Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var surInfo = await _SURRepository.GetByIdAsync(request.editSURDto.Id);
                    _mapper.Map(surInfo, request.editSURDto);
                    await _SURRepository.UpdateAsync(surInfo);
                    response.Success = true;
                    response.Message = "Edit Successful";
                }
                return response;
            }
        }
        #endregion

        #region DeleteSRp
        public class DeleteSURRequestCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteSURHandlerCommand : IRequestHandler<DeleteSURRequestCommand>
        {
            private readonly ISystemsRoleUsersRepository _SURRepository;
            public DeleteSURHandlerCommand(ISystemsRoleUsersRepository sURRepository)
            {
                
                _SURRepository = sURRepository;
            }

            public async Task Handle(DeleteSURRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _SURRepository.GetByIdAsync(request.Id);
                await _SURRepository.DeleteAsync(entity);
            }
        }
        #endregion
    }
}
