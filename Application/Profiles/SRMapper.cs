using Application.Dtos.RoleDtos;
using Application.Dtos.SystemRoleDtos;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class SRMapper : Profile
    {
        public SRMapper()
        {
            CreateMap<SystemRoles, AddSystemRoleDto>().ReverseMap();
            CreateMap<SystemRoles, EditSystemRoelDto>().ReverseMap();
            CreateMap<SystemRoles, SystemRoleDto>()
                .ForMember(SR => SR.RoleName, opt => 
                opt.MapFrom(src => src.Role.Name))
                .ForMember(SR => SR.SystemName, opt =>
                opt.MapFrom(src => src.System.Title))
                .ReverseMap();
        }
    }
}
