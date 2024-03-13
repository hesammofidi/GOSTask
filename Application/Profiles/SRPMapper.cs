using Application.Dtos.SRPDtos;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    public class SRPMapper : Profile
    {
        public SRPMapper()
        {
            CreateMap<SystemRolesPermission, AddSRPDto>().ReverseMap();
            CreateMap<SystemRolesPermission, EditSRPDto>().ReverseMap();
            CreateMap<SystemRolesPermission, SRPInfoDto>().ReverseMap();
        }
    }
}
