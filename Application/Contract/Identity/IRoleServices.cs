using Application.Dtos.RoleDtos;
using Application.Models.Abstraction;
using Domain.Users;

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
