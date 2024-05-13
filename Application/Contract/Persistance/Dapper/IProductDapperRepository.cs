using Domain.Entities;

namespace Application.Contract.Persistance.Dapper
{
    public interface IProductDapperRepository: IGenericDapperRepository<Products, int>
    {
    
    }
}
