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
    public class SURRepository : GenericRepository<SystemRoleUser,int>,
        ISystemsRoleUsersRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SURRepository> _logger;
        protected DbSet<SystemRoleUser> _set;
        public SURRepository(IdentityDatabaseContext context, 
            ILogger<SURRepository> logger) : base(context,logger)
        {
            _context = context;
            _logger = logger;
            _set = _context.Set<SystemRoleUser>();
        }
        public override async Task<PagedList<SystemRoleUser>> FilterAsync(FilterData data)
        {
            _logger.LogInformation("Filtering {text}", data.Filter);
            // Implement your specific filtering logic for SystemRoles here
            var filteredData = await _set
                .AsNoTracking()
                .Include(sr => sr.Role)
                .Include(sr => sr.System)
                .Include(sr => sr.users)
                .Filter(data.Filter)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return filteredData;
        }

        public override async Task<PagedList<SystemRoleUser>> SearchAsync(SearchData data)
        {
            _logger.LogInformation("Searching {text}", data.SearchText);
            // Implement your specific searching logic for SystemRoles here
            var lambda = PersistenceHelpers.BuildLambdaPredicate<SystemRoleUser>(data);
            var searchData = await _set
                .AsNoTracking()
                .Include(sr => sr.Role)
                .Include(sr => sr.System)
                .Include(sr => sr.users)
                .Where(lambda)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return searchData;
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
