using Domain.Entities;

namespace Application.Contract.Persistance.EFCore
{
    public interface IProductsRepository : IGenericEFRepository<Products, int>
    {

    }
}
