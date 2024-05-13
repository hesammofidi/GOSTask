using Application.Contract.Persistance.Dapper;
using Application.Contract.Persistance.EFCore;
using Application.Dtos.CommonDtos;
using Application.Dtos.PeopleDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;


namespace Application.Features.PeopleFeatures.Query
{
    public class PeopleRequestsHandlersQuery
    {
        #region Filter
        public class PeopleFilterQueryRequest : IRequest<PagedList<PeopleDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class PeopleFilterQueryHandler : IRequestHandler<PeopleFilterQueryRequest, PagedList<PeopleDto>>
        {
            private readonly IMapper _mapper;
            private readonly IPeopleRepository _peopleRepository;
            public PeopleFilterQueryHandler(IMapper mapper, IPeopleRepository peopleRepository)
            {
                _mapper = mapper;
                _peopleRepository = peopleRepository;
            }
            public async Task<PagedList<PeopleDto>> Handle(PeopleFilterQueryRequest request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var People = await _peopleRepository.FilterAsync(filterdata);
                var PeopleItems = _mapper.Map<List<PeopleDto>>(People.Items);
                return new PagedList<PeopleDto>
                    (
                    PeopleItems,
                    People.Paging.PageSize,
                    People.Paging.CurrentPage,
                    People.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region Serch
        public class PeopleSearchQueryRequest : IRequest<PagedList<PeopleDto>>
        {
            public SearchDataDto? SearchDataDto { get; set; }
        }
        public class PeopleSearchQueryHandler : IRequestHandler<PeopleSearchQueryRequest, PagedList<PeopleDto>>
        {
            private readonly IMapper _mapper;
            private readonly IPeopleRepository _peopleRepository;
            public PeopleSearchQueryHandler(IMapper mapper, IPeopleRepository peopleRepository)
            {
                _mapper = mapper;
                _peopleRepository = peopleRepository;
            }
            public async Task<PagedList<PeopleDto>> Handle(PeopleSearchQueryRequest request, CancellationToken cancellationToken)
            {
                var searchdata = _mapper.Map<SearchData>(request.SearchDataDto);
                var People = await _peopleRepository.SearchAsync(searchdata);
                var PeopleItems = _mapper.Map<List<PeopleDto>>(People.Items);
                return new PagedList<PeopleDto>
                    (
                    PeopleItems,
                    People.Paging.PageSize,
                    People.Paging.CurrentPage,
                    People.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region GetById
        public class GetPeopleRequestQuery : IRequest<PeopleDto>
        {
            public int PeopleId { get; set; }
        }
        public class GetPeopleHandlerQuery : IRequestHandler<GetPeopleRequestQuery, PeopleDto>
        {
            private readonly IMapper _mapper;
            private readonly IPeopleDapperRepository _peopleRepository;

            public GetPeopleHandlerQuery(IPeopleDapperRepository peopleRepository, IMapper mapper)
            {
                _peopleRepository = peopleRepository;
                _mapper = mapper;
            }

            public async Task<PeopleDto> Handle(GetPeopleRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _peopleRepository.GetByIdAsync(request.PeopleId);
                var Orderrp = _mapper.Map<PeopleDto>(entity);
                return Orderrp;
            }
        }
        #endregion

        #region GetAll
        public class GetAllPeopleRequestQuery : IRequest<IEnumerable<PeopleDto>>
        {
          
        }
        public class GetAllPeopleHandlerQuery : IRequestHandler<GetAllPeopleRequestQuery, IEnumerable<PeopleDto>>
        {
            private readonly IMapper _mapper;
            private readonly IPeopleDapperRepository _peopleRepository;

            public GetAllPeopleHandlerQuery(IPeopleDapperRepository peopleRepository, IMapper mapper)
            {
                _peopleRepository = peopleRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<PeopleDto>> Handle(GetAllPeopleRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _peopleRepository.GetAllAsync();
                var People = _mapper.Map<IEnumerable<PeopleDto>>(entity);
                return People;
            }
        }
        #endregion
    }
}
