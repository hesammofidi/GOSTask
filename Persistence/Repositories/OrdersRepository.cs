using Application.Contract.Persistance.OrdersRolesManagment;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OrdersRepository : GenericRepository<Orders,int> , IOrdersRepository
    {
        private readonly IdentityDatabaseContext _context;
        private readonly ILogger<OrdersRepository> _logger;
        public OrdersRepository(IdentityDatabaseContext context, ILogger<OrdersRepository> logger)
            : base(context,logger) 
        {
            _context = context;
            _logger = logger;
        }

    }
}
