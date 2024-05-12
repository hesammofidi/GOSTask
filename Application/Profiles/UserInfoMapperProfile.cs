using Application.Models.IdentityModels.UserModels;
using AutoMapper;
using Domain.Users;

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
