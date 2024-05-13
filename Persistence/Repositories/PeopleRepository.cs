using Application.Contract.Persistance.EFCore;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class PeopleRepository : GenericEFRepository<People,int>,
        IPeopleRepository
    {
        public PeopleRepository(IdentityDatabaseContext context, 
            ILogger<PeopleRepository> logger) : base(context,logger)
        {
        }
    
    }
}
