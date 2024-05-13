using Domain.Entities;

namespace Application.Contract.Persistance.EFCore
{
    public interface IOrderProductRepository : IGenericEFRepository<OrderProduct, int>
    {

    }
}
