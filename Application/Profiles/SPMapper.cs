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
            CreateMap<SystemPermission, EditSPDto>().ReverseMap();
            CreateMap<SystemPermission, SystemPermissionDto>()
                .ForMember(SP => SP.PermissionName, opt => 
                opt.MapFrom(src => src.Permission.Title))
                 .ForMember(SP => SP.SystemName, opt =>
                opt.MapFrom(src => src.System.Title))
                .ReverseMap();
        }
    }
}
