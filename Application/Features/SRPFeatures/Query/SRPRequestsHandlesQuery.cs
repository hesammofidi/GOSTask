using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SRPDtos;
using Application.Dtos.SystemPermissionDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SRPFeatures.Query
{
    public class SRPRequestsHandlesQuery
    {
        #region Filter
        public class SRPFilterQueryRequest : IRequest<PagedList<SRPInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class SRPFilterQueryHandler : IRequestHandler<SRPFilterQueryRequest, PagedList<SRPInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolesProductsRepository _SRPRepository;
            public SRPFilterQueryHandler(IMapper mapper,
                ISystemsRolesProductsRepository sRPRepository)
            {
                _mapper = mapper;
                _SRPRepository = sRPRepository;
            }
            public async Task<PagedList<SRPInfoDto>> Handle(SRPFilterQueryRequest request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var srpInfo = await _SRPRepository.FilterAsync(filterdata);
                var srpInfoItems = _mapper.Map<List<SRPInfoDto>>(srpInfo.Items);
                return new PagedList<SRPInfoDto>
                    (
                    srpInfoItems,
                    srpInfo.Paging.PageSize,
                    srpInfo.Paging.CurrentPage,
                    srpInfo.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region Serch
        public class SRpSerchQueryRequest : IRequest<PagedList<SRPInfoDto>>
        {
            public SearchDataDto? SearchDataDto { get; set; }
        }
        public class SrpSerchQueryHandler : IRequestHandler<SRpSerchQueryRequest, 
            PagedList<SRPInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolesProductsRepository _SRPRepository;
            public SrpSerchQueryHandler(IMapper mapper,
                ISystemsRolesProductsRepository sRPRepository)
            {
                _mapper = mapper;
                _SRPRepository = sRPRepository;
            }
            public async Task<PagedList<SRPInfoDto>> Handle(SRpSerchQueryRequest request, CancellationToken cancellationToken)
            {
                var searchdata = _mapper.Map<SearchData>(request.SearchDataDto);
                var srpInfo = await _SRPRepository.SearchAsync(searchdata);
                var srpInfoItems = _mapper.Map<List<SRPInfoDto>>(srpInfo.Items);
                return new PagedList<SRPInfoDto>
                    (
                    srpInfoItems,
                    srpInfo.Paging.PageSize,
                    srpInfo.Paging.CurrentPage,
                    srpInfo.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region GetById
        public class GetSRPRequestQuery : IRequest<SRPInfoDto>
        {
            public int SRPId { get; set; }
        }
        public class GetSRPHandlerQuery : IRequestHandler<GetSRPRequestQuery, SRPInfoDto>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolesProductsRepository _SRPRepository;

            public GetSRPHandlerQuery(IMapper mapper,
                ISystemsRolesProductsRepository sRPRepository)
            {
                _mapper = mapper;
                _SRPRepository = sRPRepository;
            }

            public async Task<SRPInfoDto> Handle(GetSRPRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _SRPRepository.GetByIdAsync(request.SRPId);
                var systemrp = _mapper.Map<SRPInfoDto>(entity);
                return systemrp;
            }
        }
        #endregion

        #region GetPermissions
        public class GetPermissionsRequestCommand : IRequest<List<int>>
        {
            public int SystemId { get; set; }
            public string RoleId { get; set; }
        }

        public class GetPermissionsHandlerCommand : IRequestHandler<GetPermissionsRequestCommand, List<int>>
        {
            private readonly ISystemsRolesProductsRepository _SRPRepository;

            public GetPermissionsHandlerCommand(ISystemsRolesProductsRepository sRPRepository)
            {
                _SRPRepository = sRPRepository;
            }

            public async Task<List<int>> Handle(GetPermissionsRequestCommand request, CancellationToken cancellationToken)
            {
                var srpList = await _SRPRepository.GetPermissions(request.SystemId, request.RoleId);
                return srpList;
            }
        }

        #endregion

    }
}
