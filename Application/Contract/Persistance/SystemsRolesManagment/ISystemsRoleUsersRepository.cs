using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Persistance.SystemsRolesManagment
{
    public interface ISystemsRoleUsersRepository : IGenericSqlRepository<SystemRoleUser, int>
    {
        Task<bool> ExistSRU(string UserId, int systemId, string RoleId);
        Task<bool> ExistSRUInEdit(string UserId, int systemId, string RoleId, int Id);
    }
}
