using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SystemPermissionDtos;
using Application.Dtos.SystemRoleDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SystemPermissionFeatures.Query
{
    public class SPRequestsHandlersQuery
    {
        #region Filter
        public class SPFilterQueryRequest : IRequest<PagedList<SystemPermissionDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class SPFilterQueryHandler : IRequestHandler<SPFilterQueryRequest, PagedList<SystemPermissionDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsPermissionsRepository _systemPermissionRepository;
            public SPFilterQueryHandler(IMapper mapper, ISystemsPermissionsRepository systemPermissionRepository)
            {
                _mapper = mapper;
                _systemPermissionRepository = systemPermissionRepository;
            }
            public async Task<PagedList<SystemPermissionDto>> Handle(SPFilterQueryRequest request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var systemPermission = await _systemPermissionRepository.FilterAsync(filterdata);
                var systemPermissionItems = _mapper.Map<List<SystemPermissionDto>>(systemPermission.Items);
                return new PagedList<SystemPermissionDto>
                    (
                    systemPermissionItems,
                    systemPermission.Paging.PageSize,
                    systemPermission.Paging.CurrentPage,
                    systemPermission.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region Serch
        public class SpSerchQueryRequest : IRequest<PagedList<SystemPermissionDto>>
        {
            public SearchDataDto? SearchDataDto { get; set; }
        }
        public class SpSerchQueryHandler : IRequestHandler<SpSerchQueryRequest, PagedList<SystemPermissionDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsPermissionsRepository _systemPermissionRepository;
            public SpSerchQueryHandler(IMapper mapper, ISystemsPermissionsRepository systemPermissionRepository)
            {
                _mapper = mapper;
                _systemPermissionRepository = systemPermissionRepository;
            }
            public async Task<PagedList<SystemPermissionDto>> Handle(SpSerchQueryRequest request, CancellationToken cancellationToken)
            {
                var searchdata = _mapper.Map<SearchData>(request.SearchDataDto);
                var systemPermission = await _systemPermissionRepository.SearchAsync(searchdata);
                var systemPermissionItems = _mapper.Map<List<SystemPermissionDto>>(systemPermission.Items);
                return new PagedList<SystemPermissionDto>
                    (
                    systemPermissionItems,
                    systemPermission.Paging.PageSize,
                    systemPermission.Paging.CurrentPage,
                    systemPermission.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region GetById
        public class GetSPRequestQuery : IRequest<SystemPermissionDto>
        {
            public int SPId { get; set; }
        }
        public class GetSPHandlerQuery : IRequestHandler<GetSPRequestQuery, SystemPermissionDto>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsPermissionsRepository _systemPermissionRepository;

            public GetSPHandlerQuery(ISystemsPermissionsRepository systemPermissionRepository, IMapper mapper)
            {
                _systemPermissionRepository = systemPermissionRepository;
                _mapper = mapper;
            }

            public async Task<SystemPermissionDto> Handle(GetSPRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _systemPermissionRepository.GetByIdAsync(request.SPId);
                var systemrp = _mapper.Map<SystemPermissionDto>(entity);
                return systemrp;
            }
        }
        #endregion
    }
}
