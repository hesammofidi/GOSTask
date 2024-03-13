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
            CreateMap<SystemRoleUser, SURInfoDto>().ReverseMap();
        }
    }
}
