using Application.Dtos.CommonDtos;
using Application.Models.Abstraction;
using AutoMapper;

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
