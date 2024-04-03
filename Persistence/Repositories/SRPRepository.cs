using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Models.Abstraction;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SRPRepository : 
        GenericRepository<SystemRolesPermission, int>,
        ISystemsRolesPermissionRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SRPRepository> _logger;
        protected DbSet<SystemRolesPermission> _set;
        public SRPRepository(ILogger<SRPRepository> logger,
            IdentityDatabaseContext context)
            :base(context,logger)
        {
            _logger = logger;
            _context = context;
            _set = _context.Set<SystemRolesPermission>();
        }
        public override async Task<PagedList<SystemRolesPermission>> FilterAsync(FilterData data)
        {
            _logger.LogInformation("Filtering {text}", data.Filter);
            // Implement your specific filtering logic for SystemRoles here
            var filteredData = await _set
                .AsNoTracking()
                .Include(sr => sr.Permission)
                .Include(sr => sr.Role)
                .Include(sr => sr.System)
                .Filter(data.Filter)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return filteredData;
        }

        public override async Task<PagedList<SystemRolesPermission>> SearchAsync(SearchData data)
        {
            _logger.LogInformation("Searching {text}", data.SearchText);
            // Implement your specific searching logic for SystemRoles here
            var lambda = PersistenceHelpers.BuildLambdaPredicate<SystemRolesPermission>(data);
            var searchData = await _set
                .AsNoTracking()
                .Include(sr => sr.Permission)
                .Include(sr => sr.System)
                .Include(sr => sr.Role)
                .Where(lambda)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return searchData;
        }
        public async Task<bool> ExistSRP(int PermissionId, int systemId, string RoleId)
        {
            return await _context.SystemRolesPermission.AnyAsync(srp =>
            srp.PermissionId == PermissionId
            && srp.RoleId == RoleId
            && srp.systemId == systemId);
        }

        public async Task<bool> ExistSRPInEdit(int PermissionId, int systemId, string RoleId, int Id)
        {
            return await _context.SystemRolesPermission.AnyAsync(srp =>
            srp.PermissionId == PermissionId
            && srp.RoleId == RoleId
            && srp.systemId == systemId
            && srp.Id!=Id);
        }

        public async Task<List<int>> GetPermissions(int systemId, string RoleId)
        {
            var srpList = await _context.SystemRolesPermission
                .AsNoTracking()
                .Where(s => s.systemId == systemId && s.RoleId == RoleId)
                .Select(srp => srp.PermissionId)
                .ToListAsync();
            return srpList;
        }
    }
}
