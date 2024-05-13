using Application.Dtos.OrderProductDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class OrderProductMapper : Profile
    {
        public OrderProductMapper()
        {
            CreateMap<OrderProduct, AddOrderProductDto>().ReverseMap();
            CreateMap<OrderProduct, EditOrderProductDto>().ReverseMap();
            CreateMap<OrderProduct, OrderProductDto>()
                  .ForMember(SR => SR.ProductName, opt =>
              opt.MapFrom(src => src.product.Title))
            .ForMember(SR => SR.OrderTitle, opt =>
              opt.MapFrom(src => src.Order.Title))
                .ReverseMap();
        }
    }
}
