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
            CreateMap<SystemUserRolePermission, SURPInfoDto>()
                .ForMember(SURP => SURP.RoleName, opt =>
                opt.MapFrom(src => src.Role.Name))
                .ForMember(SURP => SURP.SystemName, opt =>
                opt.MapFrom(src => src.System.Title))
                 .ForMember(SURP => SURP.PermissionName, opt =>
                opt.MapFrom(src => src.Permission.Title))
                 .ForMember(SURP => SURP.UserName, opt =>
                opt.MapFrom(src => src.users.FullName))
                .ReverseMap();
        }
    }
}
