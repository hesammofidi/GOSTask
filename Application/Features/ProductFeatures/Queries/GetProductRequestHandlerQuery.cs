using Application.Contract.Identity;
using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.ProductDtos;
using Application.Dtos.RoleDtos;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetProductsRequestHandlerQuery
    {
        #region FilterandSerch
        public class GetProductFilterRequestQuery : IRequest<PagedList<ProductInfoDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class GetProductFilterHandlerQuery : IRequestHandler<GetProductFilterRequestQuery, PagedList<ProductInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IProductsRepository _ProductsRepository;
            public GetProductFilterHandlerQuery(IMapper mapper, IProductsRepository ProductsRepository)
            {
                _mapper = mapper;
                _ProductsRepository = ProductsRepository;
            }
            public async Task<PagedList<ProductInfoDto>> Handle(GetProductFilterRequestQuery request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var Products = await _ProductsRepository.FilterAsync(filterdata);
                var ProductItems = _mapper.Map<List<ProductInfoDto>>(Products.Items);
                return new PagedList<ProductInfoDto>(ProductItems, Products.Paging.PageSize, Products.Paging.CurrentPage, Products.Paging.TotalRecordCount);
            }
        }

        public class GetProductSearchRequestQuery : IRequest<PagedList<ProductInfoDto>>
        {
            public SearchDataDto? searchDataDto { get; set; }
        }
        public class GetProductSearchHandlerQuery : IRequestHandler<GetProductSearchRequestQuery, PagedList<ProductInfoDto>>
        {
            private readonly IMapper _mapper;
            private readonly IProductsRepository _ProductsRepository;
            public GetProductSearchHandlerQuery(IMapper mapper, IProductsRepository ProductsRepository)
            {
                _mapper = mapper;
                _ProductsRepository = ProductsRepository;
            }
            public async Task<PagedList<ProductInfoDto>> Handle(GetProductSearchRequestQuery request, CancellationToken cancellationToken)
            {
                var searchData = _mapper.Map<SearchData>(request.searchDataDto);
                var Products = await _ProductsRepository.SearchAsync(searchData);
                var ProductItems = _mapper.Map<List<ProductInfoDto>>(Products.Items);
                return new PagedList<ProductInfoDto>(ProductItems, Products.Paging.PageSize, Products.Paging.CurrentPage, Products.Paging.TotalRecordCount);

            }
        }
        #endregion

        #region GetById
        public class GetProductRequestQuery : IRequest<ProductInfoDto>
        {
            public int ProductId { get; set; }
        }
        public class GetProductHandlerQuery : IRequestHandler<GetProductRequestQuery, ProductInfoDto>
        {
            private readonly IMapper _mapper;
            private readonly IProductsRepository _ProductsRepository;

            public GetProductHandlerQuery(IProductsRepository ProductsRepository, IMapper mapper)
            {
                _ProductsRepository = ProductsRepository;
                _mapper = mapper;
            }

            public async Task<ProductInfoDto> Handle(GetProductRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _ProductsRepository.GetByIdAsync(request.ProductId);
                var Product = _mapper.Map<ProductInfoDto>(entity);
                return Product;
            }
        }
        #endregion
    }
}
