using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.PermissionsDtos;
using Application.Dtos.SystemsDto;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;

namespace Application.Features.SystemFeatures.Queries
{
    public class GetSystemsRequestHandlerQuery
    {
        #region FilterandSerch
        public class GetSystemsFilterRequestQuery : IRequest<PagedList<SystemInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class GetSystemsFilterHandlerQuery : IRequestHandler<GetSystemsFilterRequestQuery, PagedList<SystemInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRepository _systemsRepository;
            public GetSystemsFilterHandlerQuery(IMapper mapper, ISystemsRepository systemsRepository)
            {
                _mapper = mapper;
                _systemsRepository = systemsRepository;
            }
            public async Task<PagedList<SystemInfoDto>> Handle(GetSystemsFilterRequestQuery request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var systems = await _systemsRepository.FilterAsync(filterdata);
                var systemItems = _mapper.Map<List<SystemInfoDto>>(systems.Items);
                return new PagedList<SystemInfoDto>(systemItems, systems.Paging.PageSize, systems.Paging.CurrentPage, systems.Paging.TotalRecordCount);
            }
        }

        public class GetSystemsSearchRequestQuery : IRequest<PagedList<SystemInfoDto>>
        {
            public SearchDataDto? searchDataDto { get; set; }
        }
        public class GetSystemsSearchHandlerQuery : IRequestHandler<GetSystemsSearchRequestQuery, PagedList<SystemInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRepository _systemsRepository;
            public GetSystemsSearchHandlerQuery(IMapper mapper, ISystemsRepository systemsRepository)
            {
                _mapper = mapper;
                _systemsRepository = systemsRepository;
            }
            public async Task<PagedList<SystemInfoDto>> Handle(GetSystemsSearchRequestQuery request, CancellationToken cancellationToken)
            {
                var searchData = _mapper.Map<SearchData>(request.searchDataDto);
                var systems = await _systemsRepository.SearchAsync(searchData);
                var systemItems = _mapper.Map<List<SystemInfoDto>>(systems.Items);
                return new PagedList<SystemInfoDto>(systemItems, systems.Paging.PageSize, systems.Paging.CurrentPage, systems.Paging.TotalRecordCount);

            }
        }
        #endregion

        #region GetById
        public class GetSystemsRequestQuery : IRequest<SystemInfoDto>
        {
            public int systemId { get; set; }
        }
        public class GetSystemsHandlerQuery : IRequestHandler<GetSystemsRequestQuery, SystemInfoDto>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRepository _systemsRepository;

            public GetSystemsHandlerQuery(ISystemsRepository systemsRepository, IMapper mapper)
            {
                _systemsRepository = systemsRepository;
                _mapper = mapper;
            }

            public async Task<SystemInfoDto> Handle(GetSystemsRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _systemsRepository.GetByIdAsync(request.systemId);
                var system = _mapper.Map<SystemInfoDto>(entity);
                return system;
            }
        }
        #endregion
    }
}
