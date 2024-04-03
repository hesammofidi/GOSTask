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
    public class SURPRepository : GenericRepository<SystemUserRolePermission, int>, ISystemsRolePermissionUsersRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SURPRepository> _logger;
        protected DbSet<SystemUserRolePermission> _set;
        public SURPRepository(IdentityDatabaseContext context,
            ILogger<SURPRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _set = _context.Set<SystemUserRolePermission>();
        }
        public override async Task<PagedList<SystemUserRolePermission>> FilterAsync(FilterData data)
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

        public override async Task<PagedList<SystemUserRolePermission>> SearchAsync(SearchData data)
        {
            _logger.LogInformation("Searching {text}", data.SearchText);
            // Implement your specific searching logic for SystemRoles here
            var lambda = PersistenceHelpers.BuildLambdaPredicate<SystemUserRolePermission>(data);
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
        public async Task<bool> ExistPermission(int PermissionId, int systemId, string UserId)
        {
            return await _context.SystemUserRolePermission.AnyAsync(srp =>
           srp.usersId == UserId
           && srp.systemId == systemId
           && srp.PermissionId == PermissionId);
        }

        public async Task<bool> ExistSURP(int PermissionId, int systemId, string RoleId, string UserId)
        {
            return await _context.SystemUserRolePermission.AnyAsync(srp =>
            srp.usersId == UserId
            && srp.RoleId == RoleId
            && srp.systemId == systemId
            && srp.PermissionId == PermissionId);
        }

        public async Task<bool> ExistSURPInEdit(int PermissionId, int systemId, string RoleId, int Id, string UserId)
        {
            return await _context.SystemUserRolePermission.AnyAsync(srp =>
          srp.usersId == UserId
          && srp.RoleId == RoleId
          && srp.systemId == systemId
          && srp.Id != Id
          && srp.PermissionId==PermissionId);
        }
    }
}
