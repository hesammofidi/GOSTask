using Application.Contract.Identity;
using Application.Dtos.RoleDtos;
using Application.Models.Abstraction;
using Domain;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Helpers;

namespace Persistence.Repositories
{
    public class RoleServices : IRoleServices
    {
        private readonly RoleManager<Roles> _roleManager;
        private IdentityDatabaseContext _context;
        // private DbSet<TEntity> _set;
        protected DbSet<Roles> _set;
        public RoleServices(
            RoleManager<Roles> roleManager,
            IdentityDatabaseContext context
            )
        {
            _roleManager = roleManager;
            _context = context;
            _set = _context.Set<Roles>();
        }

        public async Task AddRoleAsync(AddRoleDto addRoleDto)
        {
            var role = 
                new Roles 
                { 
                    Name = addRoleDto.Name,
                    NormalizedName=addRoleDto.NormalizedName
                };
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to add role");
            }
        }

        public async Task EditRoleAsync(EditRoleDto editRoleDto)
        {
            var role = await _roleManager.FindByIdAsync(editRoleDto.Id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            role.Name = editRoleDto.Name;
            role.NormalizedName = editRoleDto.NormalizedName;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to edit role");
            }
        }

        public async Task<PagedList<Roles>> FilterRoleAsync(FilterData data)
        {
            return await _set
                         .AsNoTracking()
                         .Filter(data.Filter)
                         .Sort(data.Sort)
                         .PageAsync(data.PageSize, data.PageIndex);
        }

        public async Task<PagedList<Roles>> SearchRoleAsync(SearchData data)
        {
            return await _set.AsNoTracking()
                .Where(role => EF.Functions.Like(role.Name, $"%{data.SearchText}%") ||
                               EF.Functions.Like(role.Id, $"%{data.SearchText}%") 
                              )
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
        }

        public async Task DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to delete role");
            }
        }

    }
}
