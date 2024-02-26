using Application.Dtos.CommonDtos;
using Application.Models.Abstraction;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class CommonMappers : Profile
    {
        public CommonMappers()
        {
            CreateMap<FilterDataDto, FilterData>().ReverseMap();
            CreateMap<SearchDataDto, SearchData>().ReverseMap();
        }
    }
}
