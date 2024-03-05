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
    public class SystemsRepository : GenericRepository<Systems,int> , ISystemsRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<SystemsRepository> _logger;
        public SystemsRepository(IdentityDatabaseContext context, ILogger<SystemsRepository> logger)
            : base(context,logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> ExistTitle(string title)
        {
            return await _context.Systems.AnyAsync(s => s.Title == title);

        }

        public async Task<bool> ExistTitleInEdit(string title, int Id)
        {
            return await _context.Systems.AnyAsync(s => s.Title == title &&s.Id!=Id);
        }
    }
}
