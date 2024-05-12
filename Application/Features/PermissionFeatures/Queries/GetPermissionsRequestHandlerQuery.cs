using Application.Contract.Identity;
using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.ProductDtos;
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
        public class GetPermissionFilterRequestQuery : IRequest<PagedList<ProductInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class GetPermissionFilterHandlerQuery : IRequestHandler<GetPermissionFilterRequestQuery, PagedList<ProductInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IProductsRepository _permissionsRepository;
            public GetPermissionFilterHandlerQuery(IMapper mapper, IProductsRepository permissionsRepository)
            {
                _mapper = mapper;
                _permissionsRepository = permissionsRepository;
            }
            public async Task<PagedList<ProductInfoDto>> Handle(GetPermissionFilterRequestQuery request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var Permissions = await _permissionsRepository.FilterAsync(filterdata);
                var permissionItems = _mapper.Map<List<ProductInfoDto>>(Permissions.Items);
                return new PagedList<ProductInfoDto>(permissionItems, Permissions.Paging.PageSize, Permissions.Paging.CurrentPage, Permissions.Paging.TotalRecordCount);
            }
        }

        public class GetPermissionSearchRequestQuery : IRequest<PagedList<ProductInfoDto>>
        {
            public SearchDataDto? searchDataDto { get; set; }
        }
        public class GetPermissionSearchHandlerQuery : IRequestHandler<GetPermissionSearchRequestQuery, PagedList<ProductInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IProductsRepository _permissionsRepository;
            public GetPermissionSearchHandlerQuery(IMapper mapper, IProductsRepository permissionsRepository)
            {
                _mapper = mapper;
                _permissionsRepository = permissionsRepository;
            }
            public async Task<PagedList<ProductInfoDto>> Handle(GetPermissionSearchRequestQuery request, CancellationToken cancellationToken)
            {
                var searchData = _mapper.Map<SearchData>(request.searchDataDto);
                var Permissions = await _permissionsRepository.SearchAsync(searchData);
                var permissionItems = _mapper.Map<List<ProductInfoDto>>(Permissions.Items);
                return new PagedList<ProductInfoDto>(permissionItems, Permissions.Paging.PageSize, Permissions.Paging.CurrentPage, Permissions.Paging.TotalRecordCount);

            }
        }
        #endregion

        #region GetById
        public class GetPermissionRequestQuery : IRequest<ProductInfoDto>
        {
            public int permissionId { get; set; }
        }
        public class GetPermissionHandlerQuery : IRequestHandler<GetPermissionRequestQuery, ProductInfoDto>
        {
            private readonly IMapper _mapper;
            private readonly IProductsRepository _permissionsRepository;

            public GetPermissionHandlerQuery(IProductsRepository permissionsRepository, IMapper mapper)
            {
                _permissionsRepository = permissionsRepository;
                _mapper = mapper;
            }

            public async Task<ProductInfoDto> Handle(GetPermissionRequestQuery request, CancellationToken cancellationToken)
            {
               var entity = await _permissionsRepository.GetByIdAsync(request.permissionId);
                var permission = _mapper.Map<ProductInfoDto>(entity);
                return permission;
            }
        }
        #endregion
    }
}
