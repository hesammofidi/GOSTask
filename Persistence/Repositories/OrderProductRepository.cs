using Application.Contract.Persistance.EFCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OrderProductRepository : GenericEFRepository<OrderProduct,int>, IOrderProductRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<OrderProductRepository> _logger;
        protected DbSet<OrderProduct> _set;
        public OrderProductRepository(IdentityDatabaseContext context, ILogger<OrderProductRepository> logger)
            :base(context,logger)
        {
            _context = context;
            _logger = logger;
            _set = _context.Set<OrderProduct>();
        }
    }
}
