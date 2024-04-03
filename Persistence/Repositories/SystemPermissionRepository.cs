using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Models.Abstraction;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Helpers;

namespace Persistence.Repositories
{
    public class SystemPermissionRepository : GenericRepository<SystemPermission, int>, ISystemsPermissionsRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SystemPermissionRepository> _logger;
        protected DbSet<SystemPermission> _set;
        public SystemPermissionRepository(IdentityDatabaseContext context, ILogger<SystemPermissionRepository> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _set = _context.Set<SystemPermission>();
        }
        public override async Task<PagedList<SystemPermission>> FilterAsync(FilterData data)
        {
            _logger.LogInformation("Filtering {text}", data.Filter);
            // Implement your specific filtering logic for SystemRoles here
            var filteredData = await _set
                .AsNoTracking()
                .Include(sr => sr.Permission)
                .Include(sr => sr.System)
                .Filter(data.Filter)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return filteredData;
        }

        public override async Task<PagedList<SystemPermission>> SearchAsync(SearchData data)
        {
            _logger.LogInformation("Searching {text}", data.SearchText);
            // Implement your specific searching logic for SystemRoles here
            var lambda = PersistenceHelpers.BuildLambdaPredicate<SystemPermission>(data);
            var searchData = await _set
                .AsNoTracking()
                .Include(sr => sr.Permission)
                .Include(sr => sr.System)
                .Where(lambda)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return searchData;
        }

        public async Task<bool> ExistSystemPermission(int PermissionId, int systemId)
        {
            return await _context.SystemPermission.AnyAsync(sp => sp.systemId == systemId && sp.PermissionId == PermissionId);
        }

        public async Task<bool> ExistSystempermissionInEdit(int PermissionId, int systemId, int Id)
        {
            return await _context.SystemPermission.AnyAsync(sp => sp.systemId == systemId && sp.PermissionId == PermissionId&& sp.Id!=Id);
        }
    }
}
