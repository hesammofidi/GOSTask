using Application.Dtos.SRPDtos;
using Application.Dtos.SURDtos;
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
    public class SURMapper : Profile
    {
        public SURMapper()
        {
            CreateMap<SystemRoleUser, AddSURDto>().ReverseMap();
            CreateMap<SystemRoleUser, EditSURDto>().ReverseMap();
            CreateMap<SystemRoleUser, SURInfoDto>()
                .ForMember(SUR => SUR.RoleName, opt =>
               opt.MapFrom(src => src.Role.Name))
                .ForMember(SUR => SUR.SystemName, opt =>
                opt.MapFrom(src => src.System.Title))
                .ForMember(SUR => SUR.UserName, opt =>
                opt.MapFrom(src => src.users.FullName))
                .ReverseMap();
        }
    }
}
