using Application.Models.IdentityModels.UserModels;
using AutoMapper;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class UserInfoMapperProfile : Profile
    {
        public UserInfoMapperProfile()
        {
            CreateMap<DomainUser, RegistrationRequest>().ReverseMap();
            CreateMap<DomainUser, UserInfoDto>().ReverseMap();
            CreateMap<DomainUser, EditUserDto>().ReverseMap();
            
        }
    }
}
