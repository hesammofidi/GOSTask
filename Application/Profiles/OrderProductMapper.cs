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
                .ReverseMap();
        }
    }
}
