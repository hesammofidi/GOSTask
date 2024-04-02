using Application.Dtos.PermissionsDtos;
using Application.Dtos.RoleDtos;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class PermissionsMapper : Profile
    {
        public PermissionsMapper()
        {
            CreateMap<Permisions, PermissionInfoDto>().ReverseMap();
            CreateMap<Permisions, AddPermissionDto>().ReverseMap();
            CreateMap<Permisions, EditPermissionDto>().ReverseMap();
        }
    }
}
