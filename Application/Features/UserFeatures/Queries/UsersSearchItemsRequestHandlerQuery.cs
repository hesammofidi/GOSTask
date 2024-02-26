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
using static Application.Features.UserFeatures.Queries.UsersFilterItemsRequestHandlerQuery;

namespace Application.Features.UserFeatures.Queries
{
    public class UsersSearchItemsRequestHandlerQuery
    {
        public class UsersSearchItemsRequestQuery : IRequest<PagedList<UserInfoDto>>
        {
            public SearchDataDto? SearchDataDto { get; set; }
        }
        public class UsersSearchItemsHandlerQuery : IRequestHandler<UsersSearchItemsRequestQuery, PagedList<UserInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IAuthService _userService;
            public UsersSearchItemsHandlerQuery(IMapper mapper, IAuthService userService)
            {
                _mapper = mapper;
                _userService = userService;
            }

            public async Task<PagedList<UserInfoDto>> Handle(UsersSearchItemsRequestQuery request, CancellationToken cancellationToken)
            {
               var searchData = _mapper.Map<SearchData>(request.SearchDataDto);
                var users = await _userService.SearchUserAsync(searchData);
                var userItems = _mapper.Map<List<UserInfoDto>>(users.Items);
                return new PagedList<UserInfoDto>(userItems, users.Paging.PageSize, users.Paging.CurrentPage, users.Paging.TotalRecordCount);
            }
        }
    }
}
