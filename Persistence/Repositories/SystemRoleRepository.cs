using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Models.Abstraction;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Helpers;

namespace Persistence.Repositories
{
    public class SystemRoleRepository : GenericRepository<SystemRoles,int>, ISystemsRolesRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SystemRoleRepository> _logger;
        protected DbSet<SystemRoles> _set;
        public SystemRoleRepository(IdentityDatabaseContext context, ILogger<SystemRoleRepository> logger)
            :base(context,logger)
        {
            _context = context;
            _logger = logger;
            _set = _context.Set<SystemRoles>();
        }

        public override async Task<PagedList<SystemRoles>> FilterAsync(FilterData data)
        {
            _logger.LogInformation("Filtering {text}", data.Filter);
            // Implement your specific filtering logic for SystemRoles here
            var filteredData = await _set
                .AsNoTracking()
                .Include(sr => sr.Role)
                .Include(sr => sr.System)
                .Filter(data.Filter)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return filteredData;
        }

        public override async Task<PagedList<SystemRoles>> SearchAsync(SearchData data)
        {
            _logger.LogInformation("Searching {text}", data.SearchText);
            // Implement your specific searching logic for SystemRoles here
            var lambda = PersistenceHelpers.BuildLambdaPredicate<SystemRoles>(data);
            var searchData = await _set
                .AsNoTracking()
                .Include(sr => sr.Role)
                .Include(sr => sr.System)
                .Where(lambda)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return searchData;
        }
        public async Task<bool> ExistSystemRole(int systemId, string RoleId)
        {
            return await _context.SystemRoles.AnyAsync(sr=>sr.systemId==systemId && sr.RoleId==RoleId);
        }

        public async Task<bool> ExistSystemRoleInEdit(int systemId, string RoleId, int Id)
        {
            return await _context.SystemRoles.AnyAsync(sr => sr.systemId == systemId && sr.RoleId == RoleId && sr.Id!=Id);
        }
    }
}
