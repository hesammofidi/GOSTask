using Application.Dtos.ProductDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class ProductsMapper : Profile
    {
        public ProductsMapper()
        {
            CreateMap<Products, ProductInfoDto>().ReverseMap();
            CreateMap<Products, AddProductDto>().ReverseMap();
            CreateMap<Products, EditProductDto>().ReverseMap();
        }
    }
}
