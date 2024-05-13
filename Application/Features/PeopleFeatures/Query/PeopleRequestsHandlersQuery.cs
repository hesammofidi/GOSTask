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
        public class SPFilterQueryHandler : IRequestHandler<PeopleFilterQueryRequest, PagedList<PeopleDto>>
        {
            private readonly IMapper _mapper;
            private readonly IPeopleRepository _OrderProductsRepository;
            public SPFilterQueryHandler(IMapper mapper, IPeopleRepository OrderProductsRepository)
            {
                _mapper = mapper;
                _OrderProductsRepository = OrderProductsRepository;
            }
            public async Task<PagedList<PeopleDto>> Handle(PeopleFilterQueryRequest request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var OrderProduct = await _OrderProductsRepository.FilterAsync(filterdata);
                var OrderProductItems = _mapper.Map<List<PeopleDto>>(OrderProduct.Items);
                return new PagedList<PeopleDto>
                    (
                    OrderProductItems,
                    OrderProduct.Paging.PageSize,
                    OrderProduct.Paging.CurrentPage,
                    OrderProduct.Paging.TotalRecordCount
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
            private readonly IPeopleRepository _OrderProductsRepository;
            public PeopleSearchQueryHandler(IMapper mapper, IPeopleRepository OrderProductsRepository)
            {
                _mapper = mapper;
                _OrderProductsRepository = OrderProductsRepository;
            }
            public async Task<PagedList<PeopleDto>> Handle(PeopleSearchQueryRequest request, CancellationToken cancellationToken)
            {
                var searchdata = _mapper.Map<SearchData>(request.SearchDataDto);
                var OrderProduct = await _OrderProductsRepository.SearchAsync(searchdata);
                var OrderProductItems = _mapper.Map<List<PeopleDto>>(OrderProduct.Items);
                return new PagedList<PeopleDto>
                    (
                    OrderProductItems,
                    OrderProduct.Paging.PageSize,
                    OrderProduct.Paging.CurrentPage,
                    OrderProduct.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region GetById
        public class GetPeopleRequestQuery : IRequest<PeopleDto>
        {
            public int SPId { get; set; }
        }
        public class PeopleHandlerQuery : IRequestHandler<GetPeopleRequestQuery, PeopleDto>
        {
            private readonly IMapper _mapper;
            private readonly IPeopleRepository _OrderProductsRepository;

            public PeopleHandlerQuery(IPeopleRepository OrderProductsRepository, IMapper mapper)
            {
                _OrderProductsRepository = OrderProductsRepository;
                _mapper = mapper;
            }

            public async Task<PeopleDto> Handle(GetPeopleRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _OrderProductsRepository.GetByIdAsync(request.SPId);
                var Orderrp = _mapper.Map<PeopleDto>(entity);
                return Orderrp;
            }
        }
        #endregion
    }
}
