using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Persistance.SystemsRolesManagment
{
    public interface ISystemsPermissionsRepository : IGenericSqlRepository<SystemPermission, int>
    {
        Task<bool> ExistSystemPermission(int PermissionId, int systemId);
        Task<bool> ExistSystempermissionInEdit(int PermissionId, int systemId,int Id);
    }
}
