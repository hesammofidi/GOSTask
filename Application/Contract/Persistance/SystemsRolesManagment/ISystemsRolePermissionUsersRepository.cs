using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Persistance.SystemsRolesManagment
{
    public interface ISystemsRolePermissionUsersRepository : IGenericSqlRepository<SystemUserRolePermission, int>
    {

    }
}
