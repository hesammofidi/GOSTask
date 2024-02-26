using Application.Dtos.RoleDtos;
using Application.Models.Abstraction;
using Application.Models.IdentityModels.UserModels;
using Domain;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Identity
{
    public interface IRoleServices
    {
        Task AddRoleAsync(AddRoleDto addRoleDto);
        Task EditRoleAsync(EditRoleDto editRoleDto);
        Task<PagedList<Roles>> FilterRoleAsync(FilterData data);
        Task<PagedList<Roles>> SearchRoleAsync(SearchData data);
        Task DeleteRoleAsync(string roleId);
    }
}
