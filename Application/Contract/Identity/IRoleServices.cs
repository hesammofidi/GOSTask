using Application.Dtos.RoleDtos;
using Application.Models.Abstraction;
using Application.Models.IdentityModels.UserModels;
using Domain.Users;
using Order;
using Order.Collections.Generic;
using Order.Linq;
using Order.Text;
using Order.Threading.Tasks;

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
