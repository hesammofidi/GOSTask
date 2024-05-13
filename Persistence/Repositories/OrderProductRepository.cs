using Application.Contract.Persistance.EFCore;
using Application.Models.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Helpers;
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
        public async override Task<PagedList<OrderProduct>> FilterAsync(FilterData data)
        {
            var filteredData = await _set
                .AsNoTracking()
                .Include(sr => sr.product)
                .Include(sr => sr.Order)
                .Filter(data.Filter)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return filteredData;
        }
        public async override Task<PagedList<OrderProduct>> SearchAsync(SearchData data)
        {
            var lambda = PersistenceHelpers.BuildLambdaPredicate<OrderProduct>(data);
            var result = await _set
                .AsNoTracking()
                .Include(sr => sr.product)
                .Include(sr => sr.Order)
                .Where(lambda)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            return result;
        }
    }
}
