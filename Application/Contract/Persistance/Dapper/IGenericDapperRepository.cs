using Domain.Primitives.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Persistance.Dapper
{
    public interface IGenericDapperRepository<TEntity, TId>
    where TEntity : IEntity<TId>
    {
        Task<TEntity?> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
