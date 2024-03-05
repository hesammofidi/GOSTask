using Application.Contract.Persistance.SystemsRolesManagment;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SystemPermissionRepository : GenericRepository<SystemPermission, int>, ISystemsPermissionsRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SystemPermissionRepository> _logger;
        public SystemPermissionRepository(IdentityDatabaseContext context, ILogger<SystemPermissionRepository> logger)
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
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
