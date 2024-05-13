using Application.Contract.Persistance.EFCore;
using Application.Dtos.CommonDtos;
using Application.Dtos.OrderProductDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;

namespace Application.Features.OrderProduFeatures.Query
{
    public class OrderProductQueryRequestsHandlers
    {
        #region Filter
        public class OrderProductFilterQueryRequest : IRequest<PagedList<OrderProductDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class OrderProductFilterQueryHandler : IRequestHandler<OrderProductFilterQueryRequest, PagedList<OrderProductDto>>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _orderProductRepository;
            public OrderProductFilterQueryHandler(IMapper mapper, IOrderProductRepository orderProductRepository)
            {
                _mapper = mapper;
                _orderProductRepository = orderProductRepository;
            }
            public async Task<PagedList<OrderProductDto>> Handle(OrderProductFilterQueryRequest request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var systemRole = await _orderProductRepository.FilterAsync(filterdata);
                var systemRoleItems = _mapper.Map<List<OrderProductDto>>(systemRole.Items);
                return new PagedList<OrderProductDto>
                    (
                    systemRoleItems,
                    systemRole.Paging.PageSize,
                    systemRole.Paging.CurrentPage,
                    systemRole.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region Serch
        public class OrderProductSerchQueryRequest : IRequest<PagedList<OrderProductDto>>
        {
            public SearchDataDto? SearchDataDto { get; set; }
        }
        public class SRSerchQueryHandler : IRequestHandler<OrderProductSerchQueryRequest, PagedList<OrderProductDto>>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _orderProductRepository;
            public SRSerchQueryHandler(IMapper mapper, IOrderProductRepository orderProductRepository)
            {
                _mapper = mapper;
                _orderProductRepository = orderProductRepository;
            }
            public async Task<PagedList<OrderProductDto>> Handle(OrderProductSerchQueryRequest request, CancellationToken cancellationToken)
            {
                var searchdata = _mapper.Map<SearchData>(request.SearchDataDto);
                var systemRole = await _orderProductRepository.SearchAsync(searchdata);
                var systemRoleItems = _mapper.Map<List<OrderProductDto>>(systemRole.Items);
                return new PagedList<OrderProductDto>
                    (
                    systemRoleItems,
                    systemRole.Paging.PageSize,
                    systemRole.Paging.CurrentPage,
                    systemRole.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region GetById
        public class GetOrderProductRequestQuery : IRequest<OrderProductDto>
        {
            public int SRId { get; set; }
        }
        public class GetOrderProductHandlerQuery : IRequestHandler<GetOrderProductRequestQuery, OrderProductDto>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _orderProductRepository;

            public GetOrderProductHandlerQuery(IOrderProductRepository orderProductRepository, IMapper mapper)
            {
                _orderProductRepository = orderProductRepository;
                _mapper = mapper;
            }

            public async Task<OrderProductDto> Handle(GetOrderProductRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _orderProductRepository.GetByIdAsync(request.SRId);
                var systemrle = _mapper.Map<OrderProductDto>(entity);
                return systemrle;
            }
        }
        #endregion
    }
}
