using Domain.Entities;

namespace Application.Contract.Persistance.OrdersRolesManagment
{
    public interface IOrdersRepository : IGenericEFRepository<Orders, int>
    {
        
    }
}
