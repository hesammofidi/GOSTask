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
    public class SystemRoleRepository : GenericRepository<SystemRoles,int>, ISystemsRolesRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SystemRoleRepository> _logger;
        public SystemRoleRepository(IdentityDatabaseContext context, ILogger<SystemRoleRepository> logger)
            :base(context,logger)
        {
            _context = context;
            _logger = logger;
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
