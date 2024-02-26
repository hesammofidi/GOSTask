using Application.Dtos.RoleDtos;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    public class RolesMapper:Profile
    {
        public RolesMapper()
        {
            CreateMap<Roles, RoleInfoDto>().ReverseMap();
            CreateMap<Roles, AddRoleDto>().ReverseMap();
            CreateMap<Roles, EditRoleDto>().ReverseMap();

        }
    }
}
