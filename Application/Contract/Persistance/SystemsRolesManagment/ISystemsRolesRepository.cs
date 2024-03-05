using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Persistance.SystemsRolesManagment
{
    public interface ISystemsRolesRepository : IGenericSqlRepository<SystemRoles, int>
    {
        Task<bool> ExistSystemRole(int systemId, string RoleId);
        Task<bool> ExistSystemRoleInEdit(int systemId, string RoleId,int Id);
    }
}
