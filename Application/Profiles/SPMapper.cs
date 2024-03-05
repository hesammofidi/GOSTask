using Application.Dtos.SystemPermissionDtos;
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
    public class SPMapper : Profile
    {
        public SPMapper()
        {
            CreateMap<SystemPermission, AddSPDto>().ReverseMap();
            CreateMap<SystemRoles, EditSPDto>().ReverseMap();
            CreateMap<SystemRoles, SystemPermissionDto>().ReverseMap();
        }
    }
}
