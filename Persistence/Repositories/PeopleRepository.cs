using Application.Contract.Persistance.SystemsRolesManagment;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class PeopleRepository : GenericRepository<People,int>,
        IPeopleRepository
    {
        public PeopleRepository(IdentityDatabaseContext context, 
            ILogger<PeopleRepository> logger) : base(context,logger)
        {
        }
    
    }
}
