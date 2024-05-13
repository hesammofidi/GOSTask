using Application.Contract.Persistance.Dapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Persistence.Repositories.Dapper
{
    public class ProductDapperRepository : GenericDapperRepository<Products, int>, IProductDapperRepository
    {
        public ProductDapperRepository(IDbConnection connection, ILogger<ProductDapperRepository> logger)
        : base(connection, logger)
        {

        }
    }
}
