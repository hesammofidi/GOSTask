using Application.Contract.Identity;
using Application.Dtos.CommonDtos;
using Application.Dtos.RoleDtos;
using Application.Models.Abstraction;
using Application.Models.IdentityModels.UserModels;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoleFeatures.Queries
{
    public class RolesFilterItemsRequestHandlerQuery
    {
        public class RolesFilterItemsRequestQuery : IRequest<PagedList<RoleInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class RolesFilterItemsHandlerQuery : IRequestHandler<RolesFilterItemsRequestQuery, PagedList<RoleInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IRoleServices _roleServices;
            public RolesFilterItemsHandlerQuery(IMapper mapper, IRoleServices roleServices)
            {
                _mapper = mapper;
                _roleServices = roleServices;
            }
            public async Task<PagedList<RoleInfoDto>> Handle(RolesFilterItemsRequestQuery request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var roles = await _roleServices.FilterRoleAsync(filterdata);
                var roleItems = _mapper.Map<List<RoleInfoDto>>(roles.Items);
                return new PagedList<RoleInfoDto>(roleItems, roles.Paging.PageSize, roles.Paging.CurrentPage, roles.Paging.TotalRecordCount);

            }
        }
    }
}
