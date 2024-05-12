using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.SystemRoleDtos;
using Application.Dtos.SystemRoleDtos.Validators;
using Application.Dtos.SystemsDto.Validators;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.SystemRoleFeatures.Commands
{
    public class SRCommandsRequestsHandlers
    {

        #region AddSR
        public class AddSRRequestCommand : IRequest<BaseCommandResponse>
        {
            public AddSystemRoleDto? addSRDto { get; set; }
        }
        public class AddSRHandlerCommand : IRequestHandler<AddSRRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _systemRoleRepository;
            public AddSRHandlerCommand(IMapper mapper, IOrderProductRepository systemRoleRepository)
            {
                _mapper = mapper;
                _systemRoleRepository = systemRoleRepository;
            }

            public async Task<BaseCommandResponse> Handle(AddSRRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddSystemRoleValidator(_systemRoleRepository);
                var validationResult = await validator.ValidateAsync(request.addSRDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var systemInfo = _mapper.Map<OrderProduct>(request.addSRDto);
                    await _systemRoleRepository.AddAsync(systemInfo);
                    response.Success = true;
                    response.Message = "Creation Successful";
                }
                return response;
            }
        }
        #endregion

        #region Editsr
        public class EditSRRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditSystemRoelDto? ediSRDto { get; set; }
        }
        public class EditSRHandlerCommand : IRequestHandler<EditSRRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _systemRoleRepository;
            public EditSRHandlerCommand(IMapper mapper, IOrderProductRepository systemRoleRepository)
            {
                _mapper = mapper;
                _systemRoleRepository = systemRoleRepository;
            }

            public async Task<BaseCommandResponse> Handle(EditSRRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditSystemRoleValidator(_systemRoleRepository);
                var validationResult = await validator.ValidateAsync(request.ediSRDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Edit Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var systemInfo = await _systemRoleRepository.GetByIdAsync(request.ediSRDto.Id);
                    _mapper.Map(systemInfo, request.ediSRDto);
                    await _systemRoleRepository.UpdateAsync(systemInfo);
                    response.Success = true;
                    response.Message = "Edit Successful";
                }
                return response;
            }
        }
        #endregion

        #region DeleteSR
        public class DeleteSRRequestCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteSRHandlerCommand : IRequestHandler<DeleteSRRequestCommand>
        {
            private readonly IOrderProductRepository _systemRoleRepository;
            public DeleteSRHandlerCommand(IOrderProductRepository systemRoleRepository)
            {
                _systemRoleRepository = systemRoleRepository;
            }

            public async Task Handle(DeleteSRRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _systemRoleRepository.GetByIdAsync(request.Id);
                await _systemRoleRepository.DeleteAsync(entity);
            }
        }
        #endregion
    }
}
