using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.PermissionsDtos;
using Application.Dtos.SystemsDto;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SystemFeatures.Commands
{
    public class SystemRequestsHandlersCommand 
    {
        #region AddSystem
        public class AddSystemRequestCommand :IRequest<BaseCommandResponse>
        {
            public SystemInfoDto? systemDto { get; set; }
        }
        public class AddSystemHandlerCommand : IRequestHandler<AddSystemRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRepository _systemsRepository;
            public AddSystemHandlerCommand(IMapper mapper, ISystemsRepository systemsRepository)
            {
                _mapper = mapper;
                _systemsRepository = systemsRepository;
            }
            public async Task<BaseCommandResponse> Handle(AddSystemRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new SystemValidator(_systemsRepository);
                var validationResult = await validator.ValidateAsync(request.systemDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var systemInfo = _mapper.Map<Systems>(request.systemDto);
                    await _systemsRepository.AddAsync(systemInfo);
                    response.Success = true;
                    response.Message = "Creation Successful";
                }
                return response;
            }
        }
        #endregion

        #region EditSystem
        public class EditSystemRequestCommand : IRequest<BaseCommandResponse>
        {
            public SystemInfoDto? systemDto { get; set; }
        }
        public class EditSystemHandlerCommand : IRequestHandler<EditSystemRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRepository _systemsRepository;
            public EditSystemHandlerCommand(IMapper mapper, ISystemsRepository systemsRepository)
            {
                _mapper = mapper;
                _systemsRepository = systemsRepository;
            }
            public async Task<BaseCommandResponse> Handle(EditSystemRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new SystemValidator(_systemsRepository);
                var validationResult = await validator.ValidateAsync(request.systemDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    //var systemInfo = _mapper.Map<Systems>(request.systemDto);
                    //await _systemsRepository.AddAsync(systemInfo);
                    var entity = await _systemsRepository.GetByIdAsync(request.systemDto.Id);
                    _mapper.Map(request.systemDto ,entity);
                    await _systemsRepository.UpdateAsync(entity);
                    response.Success = true;
                    response.Message = "Update Successful";
                }
                return response;
            }
        }
        #endregion

        #region DeleteSystem
        public class DeleteSystemRequestCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteSystemHandlerCommand : IRequestHandler<DeleteSystemRequestCommand>
        {
            private readonly ISystemsRepository _systemsRepository;
            public DeleteSystemHandlerCommand(IMapper mapper, ISystemsRepository systemsRepository)
            {
                _systemsRepository = systemsRepository;
            }

            public async Task Handle(DeleteSystemRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _systemsRepository.GetByIdAsync(request.Id);
                await _systemsRepository.DeleteAsync(entity);
            }
        }

        #endregion
    }
}
