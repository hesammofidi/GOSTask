using Domain.Entities;

namespace Application.Contract.Persistance.EFCore
{
    public interface IOrdersRepository : IGenericEFRepository<Orders, int>
    {

    }
}
