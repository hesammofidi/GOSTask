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
            CreateMap<SystemRolesPermission, SRPInfoDto>()
                  .ForMember(SRP => SRP.RoleName, opt =>
                opt.MapFrom(src => src.Role.Name))
                .ForMember(SRP => SRP.SystemName, opt =>
                opt.MapFrom(src => src.System.Title))
                 .ForMember(SRP => SRP.PermissionName, opt =>
                opt.MapFrom(src => src.Permission.Title))
                .ReverseMap();
        }
    }
}
