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
    public class SURRepository : GenericRepository<SystemRoleUser,int>,
        ISystemsRoleUsersRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SURRepository> _logger;
        public SURRepository(IdentityDatabaseContext context, 
            ILogger<SURRepository> logger) : base(context,logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> ExistSRU(string UserId, int systemId, string RoleId)
        {
            return await _context.SystemRoleUser.AnyAsync(srp =>
            srp.usersId == UserId
            && srp.RoleId == RoleId
            && srp.systemId == systemId);
        }

        public async Task<bool> ExistSRUInEdit(string UserId, int systemId, string RoleId, int Id)
        {
            return await _context.SystemRoleUser.AnyAsync(srp =>
           srp.usersId == UserId
           && srp.RoleId == RoleId
           && srp.systemId == systemId
           && srp.Id!=Id);
        }
    }
}
