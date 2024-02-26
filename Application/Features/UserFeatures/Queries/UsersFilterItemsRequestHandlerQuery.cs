using Application.Contract.Identity;
using Application.Dtos.CommonDtos;
using Application.Models.Abstraction;
using Application.Models.IdentityModels.UserModels;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries
{
    public class UsersFilterItemsRequestHandlerQuery 
    {
        public class UsersFilterItemsRequestQuery : IRequest<PagedList<UserInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class UsersFilterItemsHandlerQuery : IRequestHandler<UsersFilterItemsRequestQuery, PagedList<UserInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IAuthService _userService;
            public UsersFilterItemsHandlerQuery(IMapper mapper, IAuthService userService)
            {
                _mapper = mapper;
                _userService = userService;
            }
            public async Task<PagedList<UserInfoDto>> Handle(UsersFilterItemsRequestQuery request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var Users = await _userService.FilterUserAsync(filterdata);
                var userItems = _mapper.Map<List<UserInfoDto>>(Users.Items);
                return new PagedList<UserInfoDto>(userItems, Users.Paging.PageSize, Users.Paging.CurrentPage, Users.Paging.TotalRecordCount);
            }
        }
    }
}
