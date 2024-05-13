using Application.Contract.Persistance.EFCore;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OrdersRepository : GenericEFRepository<Orders,int> , IOrdersRepository
    {
        public OrdersRepository(IdentityDatabaseContext context, ILogger<OrdersRepository> logger)
            : base(context,logger) 
        {
        }

    }
}
