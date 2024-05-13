using Application.Contract.Persistance.Dapper;
using Application.Contract.Persistance.EFCore;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
