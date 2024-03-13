using Application.Dtos.SURPDtos;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    public class SRUPMappers : Profile
    {
        public SRUPMappers()
        {
            CreateMap<SystemUserRolePermission, AddSURPDto>().ReverseMap();
            CreateMap<SystemUserRolePermission, EditSURPDto>().ReverseMap();
            CreateMap<SystemUserRolePermission, SURPInfoDto>().ReverseMap();
        }
    }
}
