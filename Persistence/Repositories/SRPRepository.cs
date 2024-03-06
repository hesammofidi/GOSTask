using Application.Contract.Persistance.SystemsRolesManagment;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
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
        public SRPRepository(ILogger<SRPRepository> logger,
            IdentityDatabaseContext context)
            :base(context,logger)
        {
            _logger = logger;
            _context = context;
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
    }
}
