using Domain.Entities;

namespace Application.Contract.Persistance.EFCore
{
    public interface IPeopleRepository : IGenericEFRepository<People, int>
    {

    }
}
