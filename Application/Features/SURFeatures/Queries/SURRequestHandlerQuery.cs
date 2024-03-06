using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SRPDtos;
using Application.Dtos.SURDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;

namespace Application.Features.SURFeatures.Queries
{
    public class SURRequestHandlerQuery
    {
        #region Filter
        public class SURFilterQueryRequest : IRequest<PagedList<SURInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class SURFilterQueryHandler : IRequestHandler<SURFilterQueryRequest, PagedList<SURInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRoleUsersRepository _SURRepository;
            public SURFilterQueryHandler(IMapper mapper, ISystemsRoleUsersRepository sURRepository)
            {
                _mapper = mapper;
                _SURRepository = sURRepository;
            }
            public async Task<PagedList<SURInfoDto>> Handle(SURFilterQueryRequest request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var sURInfo = await _SURRepository.FilterAsync(filterdata);
                var sURInfoItems = _mapper.Map<List<SURInfoDto>>(sURInfo.Items);
                return new PagedList<SURInfoDto>
                    (
                    sURInfoItems,
                    sURInfo.Paging.PageSize,
                    sURInfo.Paging.CurrentPage,
                    sURInfo.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region Serch
        public class SURSerchQueryRequest : IRequest<PagedList<SURInfoDto>>
        {
            public SearchDataDto? SearchDataDto { get; set; }
        }
        public class SURSerchQueryHandler : IRequestHandler<SURSerchQueryRequest,
            PagedList<SURInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRoleUsersRepository _SURRepository;
            public SURSerchQueryHandler(IMapper mapper,
                ISystemsRoleUsersRepository sURRepository)
            {
                _mapper = mapper;
                _SURRepository = sURRepository;
            }
            public async Task<PagedList<SURInfoDto>> Handle(SURSerchQueryRequest request, CancellationToken cancellationToken)
            {
                var searchdata = _mapper.Map<SearchData>(request.SearchDataDto);
                var surInfo = await _SURRepository.SearchAsync(searchdata);
                var surInfoItems = _mapper.Map<List<SURInfoDto>>(surInfo.Items);
                return new PagedList<SURInfoDto>
                    (
                    surInfoItems,
                    surInfo.Paging.PageSize,
                    surInfo.Paging.CurrentPage,
                    surInfo.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region GetById
        public class GetSURRequestQuery : IRequest<SURInfoDto>
        {
            public int SURId { get; set; }
        }
        public class GetSURHandlerQuery : IRequestHandler<GetSURRequestQuery, SURInfoDto>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolesPermissionRepository _SRPRepository;

            public GetSURHandlerQuery(IMapper mapper,
                ISystemsRolesPermissionRepository sRPRepository)
            {
                _mapper = mapper;
                _SRPRepository = sRPRepository;
            }

            public async Task<SURInfoDto> Handle(GetSURRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _SRPRepository.GetByIdAsync(request.SURId);
                var systemrp = _mapper.Map<SURInfoDto>(entity);
                return systemrp;
            }
        }
        #endregion
    }
}
