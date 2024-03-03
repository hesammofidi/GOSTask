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
    }
}
