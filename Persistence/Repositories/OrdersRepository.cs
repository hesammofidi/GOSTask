using Application.Contract.Persistance.EFCore;
using Application.Models.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Helpers;

namespace Persistence.Repositories
{
    public class OrdersRepository : GenericEFRepository<Orders,int> , IOrdersRepository
    {
        private readonly IdentityDatabaseContext _context;
        protected DbSet<Orders> _set;
        public OrdersRepository(IdentityDatabaseContext context, ILogger<OrdersRepository> logger)
            : base(context,logger) 
        {
            _context = context;
            _set = _context.Set<Orders>();
        }

        public async override Task<PagedList<Orders>> FilterAsync(FilterData data)
        {
            var filteredData = await _set
                .AsNoTracking()
                .Include(sr => sr.People)
                .Filter(data.Filter)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return filteredData;
        }

        public async override Task<PagedList<Orders>> SearchAsync(SearchData data)
        {
            var lambda = PersistenceHelpers.BuildLambdaPredicate<Orders>(data);
            var result = await _set
                .AsNoTracking()
                .Include(sr => sr.People)
                .Where(lambda)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return result;
        }

    }
}
