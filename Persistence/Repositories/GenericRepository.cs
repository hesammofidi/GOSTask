using Application.Contract.Persistance;
using Application.Models.Abstraction;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Helpers;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TId> : IGenericSqlRepository<TEntity, TId>
        where TEntity : BaseDomainEntity<TId>
    {
        private readonly IdentityDatabaseContext _context;
        protected readonly DbSet<TEntity> _set;
        private readonly ILogger<GenericRepository<TEntity, TId>> _logger;

        public GenericRepository(IdentityDatabaseContext context, 
            ILogger<GenericRepository<TEntity, TId>> logger)
        {
            _context = context;
            _logger = logger;
            _set = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            _logger.LogInformation("Adding entity");
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Successfully added entity");
           
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _logger.LogInformation("Deleting entity");
            _set.Remove(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Successfully deleted entity");
        }

        public async Task<bool> Exist(TId id)
        {
            _logger.LogInformation("Checking if entity with ID {EntityId} exists", id);
            bool exists = await _set.AnyAsync(s => s.Id.Equals(id));
            _logger.LogInformation("Entity with ID {EntityId} exists: {Exists}", id, exists);
            return exists;
        }


        public virtual async Task<PagedList<TEntity>> FilterAsync(FilterData data)
        {
            _logger.LogInformation("Filtering {text}", data.Filter);
            return await _set
                .AsNoTracking()
                .Filter(data.Filter)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            _logger.LogInformation("Getting entity with ID {EntityId}", id);
            var entity = await _set.FindAsync(id);
            if (entity != null)
            {
                _logger.LogInformation("Successfully got entity with ID {EntityId}", id);
            }
            else
            {
                _logger.LogWarning("Entity with ID {EntityId} not found", id);
            }
            return entity;
        }

        public virtual async Task<PagedList<TEntity>> SearchAsync(SearchData data)
        {
            _logger.LogInformation("searching {text}", data.SearchText);
            var lambda = PersistenceHelpers.BuildLambdaPredicate<TEntity>(data);
            return await _set
                .AsNoTracking()
                .Where(lambda)
                .Sort(data.Sort)
                .PageAsync(data.PageSize, data.PageIndex);
            
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _logger.LogInformation("Updating entity");
            _set.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Successfully updated entity");
        }

        public async Task<TEntity?> GetByNameAsync(string Name)
        {
            _logger.LogInformation("Getting entity with ID {EntityId}", Name);
            var entity = await _set.FindAsync(Name);
            if (entity != null)
            {
                _logger.LogInformation("Successfully got entity with ID {EntityId}", Name);
            }
            else
            {
                _logger.LogWarning("Entity with ID {EntityId} not found", Name);
            }
            return entity;
        }
    }
}
