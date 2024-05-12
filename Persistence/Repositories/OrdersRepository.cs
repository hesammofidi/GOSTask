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
