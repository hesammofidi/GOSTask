using Application.Dtos.ProductDtos;
using Application.Dtos.RoleDtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class PermissionsMapper : Profile
    {
        public PermissionsMapper()
        {
            CreateMap<Products, ProductInfoDto>().ReverseMap();
            CreateMap<Products, AddProductDto>().ReverseMap();
            CreateMap<Products, EditProductDto>().ReverseMap();
        }
    }
}
