using Application.Models.Abstraction;
using Domain.Primitives.Contract;
namespace Application.Contract.Persistance
{
    public interface IGenericSqlRepository<TEntity, TId>
          where TEntity : IEntity<TId>
    {
        Task<TEntity?> GetByIdAsync(TId id);
        Task<TEntity?> GetByNameAsync(string Name);
        Task<bool> Exist(TId id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<PagedList<TEntity>> FilterAsync(FilterData data);
        Task<PagedList<TEntity>> SearchAsync(SearchData data);
    }
}
