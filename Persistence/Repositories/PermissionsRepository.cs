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
    public class PermissionsRepository : GenericRepository<Permisions,int>, IPermissionsRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<PermissionsRepository> _logger;
        public PermissionsRepository(IdentityDatabaseContext context, ILogger<PermissionsRepository> logger) 
            : base(context,logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> ExistTitle(string title)
        {
            return await _context.Permission.AnyAsync(s => s.Title == title);

        }
    }
}
