using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.SystemPermissionDtos;
using Application.Dtos.SystemPermissionDtos.Validators;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SystemPermissionFeatures.Command
{
    public class SPRequestsHandlersCommad
    {
        #region AddSp
        public class AddSpRequestCommand : IRequest<BaseCommandResponse>
        {
            public AddSPDto? addSpDto { get; set; }
        }
        public class AddSpHandlerCommand : IRequestHandler<AddSpRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IOrderPeopleRepository _systemProductsRepository;
            public AddSpHandlerCommand(IMapper mapper, IOrderPeopleRepository systemProductsRepository)
            {
                _mapper = mapper;
                _systemProductsRepository = systemProductsRepository;
            }

            public async Task<BaseCommandResponse> Handle(AddSpRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new AddSystemPermissionValidator(_systemProductsRepository);
                var validationResult = await validator.ValidateAsync(request.addSpDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var spInfo = _mapper.Map<OrderPeople>(request.addSpDto);
                    await _systemProductsRepository.AddAsync(spInfo);
                    response.Success = true;
                    response.Message = "Creation Successful";
                }
                return response;
            }
        }
        #endregion

        #region Editsp
        public class EditSPRequestCommand : IRequest<BaseCommandResponse>
        {
            public EditSPDto? editSpDto { get; set; }
        }
        public class EditSPHandlerCommand : IRequestHandler<EditSPRequestCommand, BaseCommandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IOrderPeopleRepository _systemProductsRepository;
            public EditSPHandlerCommand(IMapper mapper, IOrderPeopleRepository systemProductsRepository)
            {
                _mapper = mapper;
                _systemProductsRepository = systemProductsRepository;
            }

            public async Task<BaseCommandResponse> Handle(EditSPRequestCommand request, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new EditSystemPermissionValidator(_systemProductsRepository);
                var validationResult = await validator.ValidateAsync(request.editSpDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Edit Failed";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                else
                {
                    var systemInfo = await _systemProductsRepository.GetByIdAsync(request.editSpDto.Id);
                    _mapper.Map(systemInfo, request.editSpDto);
                    await _systemProductsRepository.UpdateAsync(systemInfo);
                    response.Success = true;
                    response.Message = "Edit Successful";
                }
                return response;
            }
        }
        #endregion

        #region DeleteSp
        public class DeleteSPRequestCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteSPHandlerCommand : IRequestHandler<DeleteSPRequestCommand>
        {
            private readonly IOrderPeopleRepository _systemProductsRepository;
            public DeleteSPHandlerCommand(IOrderPeopleRepository systemProductsRepository)
            {
                _systemProductsRepository = systemProductsRepository;
            }

            public async Task Handle(DeleteSPRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _systemProductsRepository.GetByIdAsync(request.Id);
                await _systemProductsRepository.DeleteAsync(entity);
            }
        }
        #endregion
    }
}
