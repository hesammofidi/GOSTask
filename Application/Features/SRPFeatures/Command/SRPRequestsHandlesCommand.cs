using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.SRPDtos;
using Application.Dtos.SRPDtos.Validators;
using Application.Dtos.SystemPermissionDtos.Validators;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SRPFeatures.Command
{
    public class SRPRequestsHandlesCommand
    {
        #region Add
        public class AddSRPRequestCommand : IRequest<BaseCommandResponse>
        {
            public AddSRPDto addSrpDto { get; set; }
        }

        public class AddSRPHandlerCommand : IRequestHandler<AddSRPRequestCommand, BaseCommandResponse>
        {
            private readonly ISystemsRolesProductsRepository _SRPRepository;
            private readonly IMapper _mapper;

            public AddSRPHandlerCommand(
                ISystemsRolesProductsRepository sRPRepository,
                IMapper mapper)
            {
                _SRPRepository = sRPRepository;
                _mapper = mapper;
            }
            public async Task<BaseCommandResponse> Handle(AddSRPRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddSRPValidator(_SRPRepository);
                var validationResult = await validator.ValidateAsync(request.addSrpDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var srpInfo = _mapper.Map<SystemRolesPermission>(request.addSrpDto);
                    await _SRPRepository.AddAsync(srpInfo);
                    response.Success = true;
                    response.Message = "Creation Successful";
                }
                return response;
            }
        }

        #endregion

        #region Edit
        public class EditSRPRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditSRPDto editSrpDto { get; set; }
        }

        public class EditSRPHandlerCommand : IRequestHandler<EditSRPRequestCommand, BaseCommandResponse>
        {
            private readonly ISystemsRolesProductsRepository _SRPRepository;
            private readonly IMapper _mapper;

            public EditSRPHandlerCommand(
                ISystemsRolesProductsRepository sRPRepository,
                IMapper mapper)
            {
                _SRPRepository = sRPRepository;
                _mapper = mapper;
            }
            public async Task<BaseCommandResponse> Handle(EditSRPRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditSRPValidator(_SRPRepository);
                var validationResult = await validator.ValidateAsync(request.editSrpDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Edit Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var srpInfo = await _SRPRepository.GetByIdAsync(request.editSrpDto.Id);
                    _mapper.Map(srpInfo, request.editSrpDto);
                    await _SRPRepository.UpdateAsync(srpInfo);
                    response.Success = true;
                    response.Message = "Edit Successful";
                }
                return response;
            }
        }
        #endregion

        #region DeleteSRp
        public class DeleteSRPRequestCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteSRPHandlerCommand : IRequestHandler<DeleteSRPRequestCommand>
        {
            private readonly ISystemsRolesProductsRepository _SRPRepository;
            public DeleteSRPHandlerCommand(ISystemsRolesProductsRepository sRPRepository)
            {
                _SRPRepository = sRPRepository;
            }

            public async Task Handle(DeleteSRPRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _SRPRepository.GetByIdAsync(request.Id);
                await _SRPRepository.DeleteAsync(entity);
            }
        }
        #endregion
    }
}
