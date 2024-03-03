using Application.Contract.Identity;
using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.PermissionsDtos;
using Application.Dtos.RoleDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PermissionFeatures.Queries
{
    public class GetPermissionsRequestHandlerQuery
    {
        #region FilterandSerch
        public class GetPermissionFilterRequestQuery : IRequest<PagedList<PermissionInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class GetPermissionFilterHandlerQuery : IRequestHandler<GetPermissionFilterRequestQuery, PagedList<PermissionInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IPermissionsRepository _permissionsRepository;
            public GetPermissionFilterHandlerQuery(IMapper mapper, IPermissionsRepository permissionsRepository)
            {
                _mapper = mapper;
                _permissionsRepository = permissionsRepository;
            }
            public async Task<PagedList<PermissionInfoDto>> Handle(GetPermissionFilterRequestQuery request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var Permissions = await _permissionsRepository.FilterAsync(filterdata);
                var permissionItems = _mapper.Map<List<PermissionInfoDto>>(Permissions.Items);
                return new PagedList<PermissionInfoDto>(permissionItems, Permissions.Paging.PageSize, Permissions.Paging.CurrentPage, Permissions.Paging.TotalRecordCount);
            }
        }

        public class GetPermissionSearchRequestQuery : IRequest<PagedList<PermissionInfoDto>>
        {
            public SearchDataDto? searchDataDto { get; set; }
        }
        public class GetPermissionSearchHandlerQuery : IRequestHandler<GetPermissionSearchRequestQuery, PagedList<PermissionInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IPermissionsRepository _permissionsRepository;
            public GetPermissionSearchHandlerQuery(IMapper mapper, IPermissionsRepository permissionsRepository)
            {
                _mapper = mapper;
                _permissionsRepository = permissionsRepository;
            }
            public async Task<PagedList<PermissionInfoDto>> Handle(GetPermissionSearchRequestQuery request, CancellationToken cancellationToken)
            {
                var searchData = _mapper.Map<SearchData>(request.searchDataDto);
                var Permissions = await _permissionsRepository.SearchAsync(searchData);
                var permissionItems = _mapper.Map<List<PermissionInfoDto>>(Permissions.Items);
                return new PagedList<PermissionInfoDto>(permissionItems, Permissions.Paging.PageSize, Permissions.Paging.CurrentPage, Permissions.Paging.TotalRecordCount);

            }
        }
        #endregion

        #region GetById
        public class GetPermissionRequestQuery : IRequest<PermissionInfoDto>
        {
            public int permissionId { get; set; }
        }
        public class GetPermissionHandlerQuery : IRequestHandler<GetPermissionRequestQuery, PermissionInfoDto>
        {
            private readonly IMapper _mapper;
            private readonly IPermissionsRepository _permissionsRepository;

            public GetPermissionHandlerQuery(IPermissionsRepository permissionsRepository, IMapper mapper)
            {
                _permissionsRepository = permissionsRepository;
                _mapper = mapper;
            }

            public async Task<PermissionInfoDto> Handle(GetPermissionRequestQuery request, CancellationToken cancellationToken)
            {
               var entity = await _permissionsRepository.GetByIdAsync(request.permissionId);
                var permission = _mapper.Map<PermissionInfoDto>(entity);
                return permission;
            }
        }
        #endregion
    }
}
