using Application.Contract.Persistance.EFCore;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProductsRepository : GenericEFRepository<Products,int>, IProductsRepository
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
