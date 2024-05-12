using Application.Contract.Persistance.OrdersRolesManagment;
using Application.Models.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Helpers;

namespace Persistence.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct,int>, IOrderProductRepository
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
