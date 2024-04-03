using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SURPDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;

namespace Application.Features.SURPFeatures.Handler
{
    public class SURPRequestHandlerQuery
    {
        #region Filter
        public class SURPFilterQueryRequest : IRequest<PagedList<SURPInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class SURPFilterQueryHandler : IRequestHandler<SURPFilterQueryRequest, PagedList<SURPInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolePermissionUsersRepository _SURPRepository;
            public SURPFilterQueryHandler(IMapper mapper, ISystemsRolePermissionUsersRepository sURPRepository)
            {
                _mapper = mapper;
                _SURPRepository = sURPRepository;
            }
            public async Task<PagedList<SURPInfoDto>> Handle(SURPFilterQueryRequest request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var sURPInfo = await _SURPRepository.FilterAsync(filterdata);
                var sURPInfoItems = _mapper.Map<List<SURPInfoDto>>(sURPInfo.Items);
                return new PagedList<SURPInfoDto>
                    (
                    sURPInfoItems,
                    sURPInfo.Paging.PageSize,
                    sURPInfo.Paging.CurrentPage,
                    sURPInfo.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region Serch
        public class SURPSerchQueryRequest : IRequest<PagedList<SURPInfoDto>>
        {
            public SearchDataDto? SearchDataDto { get; set; }
        }
        public class SURPSerchQueryHandler : IRequestHandler<SURPSerchQueryRequest,
            PagedList<SURPInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolePermissionUsersRepository _SURPRepository;
            public SURPSerchQueryHandler(IMapper mapper,
                ISystemsRolePermissionUsersRepository sURPRepository)
            {
                _mapper = mapper;
                _SURPRepository = sURPRepository;
            }
            public async Task<PagedList<SURPInfoDto>> Handle(SURPSerchQueryRequest request, CancellationToken cancellationToken)
            {
                var searchdata = _mapper.Map<SearchData>(request.SearchDataDto);
                var surpInfo = await _SURPRepository.SearchAsync(searchdata);
                var surpInfoItems = _mapper.Map<List<SURPInfoDto>>(surpInfo.Items);
                return new PagedList<SURPInfoDto>
                    (
                    surpInfoItems,
                    surpInfo.Paging.PageSize,
                    surpInfo.Paging.CurrentPage,
                    surpInfo.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region GetById
        public class GetSURPRequestQuery : IRequest<SURPInfoDto>
        {
            public int SURPId { get; set; }
        }
        public class GetSURPHandlerQuery : IRequestHandler<GetSURPRequestQuery, SURPInfoDto>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolePermissionUsersRepository _SURPRepository;

            public GetSURPHandlerQuery(IMapper mapper,
                ISystemsRolePermissionUsersRepository sURPRepository)
            {
                _mapper = mapper;
                _SURPRepository = sURPRepository;
            }

            public async Task<SURPInfoDto> Handle(GetSURPRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _SURPRepository.GetByIdAsync(request.SURPId);
                var systemrup = _mapper.Map<SURPInfoDto>(entity);
                return systemrup;
            }
        }
        #endregion

        #region ExistPermission
        public class ExistPermissionRequest : IRequest<bool>
        {
            public string? PermisName { get; set; }
            public string? Uid { get; set; }
            public int Sid { get; set; }
        }
        public class ExistPermissionHandler : IRequestHandler<ExistPermissionRequest, bool>
        {
            private readonly ISystemsRolePermissionUsersRepository _SURPRepository;
            private readonly IPermissionsRepository _permissionRepos;
            public ExistPermissionHandler(ISystemsRolePermissionUsersRepository sURPRepository, 
                IPermissionsRepository permissionRepos)
            {
                _SURPRepository = sURPRepository;
                _permissionRepos = permissionRepos;
            }

            public async Task<bool> Handle(ExistPermissionRequest request, CancellationToken cancellationToken)
            {
                var filterData = new FilterData
                {
                    Filter = $"title = \"{request.PermisName}\"",
                    PageSize = 1  // Only need to find one matching record
                };
                var permissionItem = await _permissionRepos.FilterAsync(filterData);

                var permissionId =  permissionItem.Items.FirstOrDefault()!.Id;
                if (permissionId != null && request.Uid!=null && request.Sid!=null)
                {
                    var existperm = await _SURPRepository
                        .ExistPermission(permissionId,
                        request.Sid,
                        request.Uid);
                    return existperm;
                }
                return false;
            }
        }

        #endregion
    }
}
