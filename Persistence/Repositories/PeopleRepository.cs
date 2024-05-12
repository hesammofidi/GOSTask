using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Models.Abstraction;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
