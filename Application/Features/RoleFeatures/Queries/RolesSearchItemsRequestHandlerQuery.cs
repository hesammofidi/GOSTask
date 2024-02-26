using Application.Contract.Identity;
using Application.Dtos.CommonDtos;
using Application.Dtos.RoleDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoleFeatures.Queries
{
    public class RolesSearchItemsRequestHandlerQuery
    {
        public class RolesSearchItemsRequestQuery : IRequest<PagedList<RoleInfoDto>>
        {
            public SearchDataDto? searchDataDto { get; set; }
        }
        public class RolesFilterItemsHandlerQuery : IRequestHandler<RolesSearchItemsRequestQuery, PagedList<RoleInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IRoleServices _roleServices;
            public RolesFilterItemsHandlerQuery(IMapper mapper, IRoleServices roleServices)
            {
                _mapper = mapper;
                _roleServices = roleServices;
            }
            public async Task<PagedList<RoleInfoDto>> Handle(RolesSearchItemsRequestQuery request, CancellationToken cancellationToken)
            {
                var searchData = _mapper.Map<SearchData>(request.searchDataDto);
                var roles = await _roleServices.SearchRoleAsync(searchData);
                var roleItems = _mapper.Map<List<RoleInfoDto>>(roles.Items);
                return new PagedList<RoleInfoDto>(roleItems, roles.Paging.PageSize, roles.Paging.CurrentPage, roles.Paging.TotalRecordCount);

            }
        }
    }
}
