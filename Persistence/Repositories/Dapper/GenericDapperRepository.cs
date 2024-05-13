using Application.Contract.Persistance.Dapper;
using Dapper;
using Domain.Primitives.Contract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Dapper
{
    public class GenericDapperRepository<TEntity, TId> : IGenericDapperRepository<TEntity, TId>
    where TEntity : IEntity<TId>
    {
        private readonly IDbConnection _connection;
        private readonly ILogger<GenericDapperRepository<TEntity, TId>> _logger;

        public GenericDapperRepository(IDbConnection connection, ILogger<GenericDapperRepository<TEntity, TId>> logger)
        {
            _connection = connection;
            _logger = logger;
        }
        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            string tableName = typeof(TEntity).Name;
            _logger.LogInformation($"Getting entity with ID {id} from {tableName}");
            var entity = await _connection.QueryFirstOrDefaultAsync<TEntity>(
                $"SELECT * FROM {tableName} WHERE Id = @Id", new { Id = id });
            if (entity != null)
            {
                _logger.LogInformation($"Successfully got entity with ID {id} from {tableName}");
            }
            else
            {
                _logger.LogWarning($"Entity with ID {id} not found in {tableName}");
            }
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            string tableName = typeof(TEntity).Name;
            _logger.LogInformation($"Getting all entities from {tableName}");
            var entities = await _connection.QueryAsync<TEntity>($"SELECT * FROM {tableName}");
            _logger.LogInformation($"Successfully got all entities from {tableName}");
            return entities;
        }
    }
}
