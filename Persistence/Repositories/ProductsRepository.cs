using Application.Contract.Persistance.SystemsRolesManagment;
using Domain.Entities;
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
    public class ProductsRepository : GenericRepository<Products,int>, IProductsRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<ProductsRepository> _logger;
        public ProductsRepository(IdentityDatabaseContext context, ILogger<ProductsRepository> logger) 
            : base(context,logger)
        {
            _context = context;
            _logger = logger;
        }

      
    }
}
