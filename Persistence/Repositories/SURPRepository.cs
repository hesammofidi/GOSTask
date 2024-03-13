using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Models.Abstraction;
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
    public class SURPRepository : GenericRepository<SystemUserRolePermission, int>, ISystemsRolePermissionUsersRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SURPRepository> _logger;
        public SURPRepository(IdentityDatabaseContext context,
            ILogger<SURPRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
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
          && srp.Id == Id
          && srp.PermissionId==PermissionId);
        }
    }
}
