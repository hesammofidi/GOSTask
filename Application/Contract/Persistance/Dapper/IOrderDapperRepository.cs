using Domain.Entities;

namespace Application.Contract.Persistance.Dapper
{
    public interface IOrderDapperRepository : IGenericDapperRepository<Orders, int>
    {
    }
}
