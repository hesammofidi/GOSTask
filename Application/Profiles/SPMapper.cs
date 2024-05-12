using Application.Dtos.SystemPermissionDtos;
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
    public class SPMapper : Profile
    {
        public SPMapper()
        {
            CreateMap<OrderPeople, AddSPDto>().ReverseMap();
            CreateMap<OrderPeople, EditSPDto>().ReverseMap();
            CreateMap<OrderPeople, SystemPermissionDto>()
                .ForMember(SP => SP.PermissionName, opt => 
                opt.MapFrom(src => src.Permission.Title))
                 .ForMember(SP => SP.SystemName, opt =>
                opt.MapFrom(src => src.System.Title))
                .ReverseMap();
        }
    }
}
