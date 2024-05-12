using Application.Dtos.RoleDtos;
using Application.Dtos.SystemRoleDtos;
using AutoMapper;
using Domain.Entities;
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
            CreateMap<OrderProduct, AddSystemRoleDto>().ReverseMap();
            CreateMap<OrderProduct, EditSystemRoelDto>().ReverseMap();
            CreateMap<OrderProduct, SystemRoleDto>()
                .ReverseMap();
        }
    }
}
