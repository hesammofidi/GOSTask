using Application.Contract.Persistance.OrdersRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.OrderDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;

namespace Application.Features.OrdersFeatures.Queries
{
    public class GetOrdersRequestHandlerQuery
    {
        #region FilterandSerch
        public class GetOrdersFilterRequestQuery : IRequest<PagedList<OrderInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class GetOrdersFilterHandlerQuery : IRequestHandler<GetOrdersFilterRequestQuery, PagedList<OrderInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IOrdersRepository _OrdersRepository;
            public GetOrdersFilterHandlerQuery(IMapper mapper, IOrdersRepository OrdersRepository)
            {
                _mapper = mapper;
                _OrdersRepository = OrdersRepository;
            }
            public async Task<PagedList<OrderInfoDto>> Handle(GetOrdersFilterRequestQuery request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var Orders = await _OrdersRepository.FilterAsync(filterdata);
                var OrderItems = _mapper.Map<List<OrderInfoDto>>(Orders.Items);
                return new PagedList<OrderInfoDto>(OrderItems, Orders.Paging.PageSize, Orders.Paging.CurrentPage, Orders.Paging.TotalRecordCount);
            }
        }

        public class GetOrdersSearchRequestQuery : IRequest<PagedList<OrderInfoDto>>
        {
            public SearchDataDto? searchDataDto { get; set; }
        }
        public class GetOrdersSearchHandlerQuery : IRequestHandler<GetOrdersSearchRequestQuery, PagedList<OrderInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IOrdersRepository _OrdersRepository;
            public GetOrdersSearchHandlerQuery(IMapper mapper, IOrdersRepository OrdersRepository)
            {
                _mapper = mapper;
                _OrdersRepository = OrdersRepository;
            }
            public async Task<PagedList<OrderInfoDto>> Handle(GetOrdersSearchRequestQuery request, CancellationToken cancellationToken)
            {
                var searchData = _mapper.Map<SearchData>(request.searchDataDto);
                var Orders = await _OrdersRepository.SearchAsync(searchData);
                var OrderItems = _mapper.Map<List<OrderInfoDto>>(Orders.Items);
                return new PagedList<OrderInfoDto>(OrderItems, Orders.Paging.PageSize, Orders.Paging.CurrentPage, Orders.Paging.TotalRecordCount);

            }
        }
        #endregion

        #region GetById
        public class GetOrdersRequestQuery : IRequest<OrderInfoDto>
        {
            public int OrderId { get; set; }
        }
        public class GetOrdersHandlerQuery : IRequestHandler<GetOrdersRequestQuery, OrderInfoDto>
        {
            private readonly IMapper _mapper;
            private readonly IOrdersRepository _OrdersRepository;

            public GetOrdersHandlerQuery(IOrdersRepository OrdersRepository, IMapper mapper)
            {
                _OrdersRepository = OrdersRepository;
                _mapper = mapper;
            }

            public async Task<OrderInfoDto> Handle(GetOrdersRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _OrdersRepository.GetByIdAsync(request.OrderId);
                var Order = _mapper.Map<OrderInfoDto>(entity);
                return Order;
            }
        }
        #endregion
    }
}
