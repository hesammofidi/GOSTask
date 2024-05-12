using Application.Dtos.RoleDtos;
using Application.Dtos.SystemsDto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class SystemsMapper : Profile
    {
        public SystemsMapper()
        {
            CreateMap<Orders, AddSystemDto>().ReverseMap();
            CreateMap<Orders, EditSystemDto>().ReverseMap();
            CreateMap<Orders, SystemInfoDto>().ReverseMap();

        }
    }
}
