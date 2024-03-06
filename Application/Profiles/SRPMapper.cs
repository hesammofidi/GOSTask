using Application.Dtos.SRPDtos;
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
    public class SRPMapper : Profile
    {
        public SRPMapper()
        {
            CreateMap<SystemRolesPermission, AddSRPDto>().ReverseMap();
            CreateMap<SystemRolesPermission, EditSRPDto>().ReverseMap();
            CreateMap<SystemRolesPermission, SystemRoleDto>().ReverseMap();
        }
    }
}
