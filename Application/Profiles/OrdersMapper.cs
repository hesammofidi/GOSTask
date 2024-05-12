using Application.Dtos.OrderDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class OrdersMapper : Profile
    {
        public OrdersMapper()
        {
            CreateMap<Orders, AddOrderDto>().ReverseMap();
            CreateMap<Orders, EditOrderDto>().ReverseMap();
            CreateMap<Orders, OrderInfoDto>().ReverseMap();

        }
    }
}
