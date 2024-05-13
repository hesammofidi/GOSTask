using Application.Contract.Persistance.Dapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Dapper
{
    public class PeopleDapperRepository : GenericDapperRepository<People, int>, IPeopleDapperRepository
    {
        public PeopleDapperRepository(IDbConnection connection, ILogger<PeopleDapperRepository> logger)
        : base(connection, logger)
        {


        }
    }
}
