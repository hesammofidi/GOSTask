using Application.Dtos.PeopleDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class PeopleMapper : Profile
    {
        public PeopleMapper()
        {
            CreateMap<People, AddPeopleDto>().ReverseMap();
            CreateMap<People, EditPeopleDto>().ReverseMap();
            CreateMap<People, PeopleDto>()
                .ReverseMap();
        }
    }
}
