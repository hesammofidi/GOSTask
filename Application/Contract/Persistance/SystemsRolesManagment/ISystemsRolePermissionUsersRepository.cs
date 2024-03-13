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
        Task<bool> ExistSURP(int PermissionId, int systemId, string RoleId,string UserId);
        Task<bool> ExistSURPInEdit(int PermissionId, int systemId, string RoleId, int Id, string UserId);
        Task<bool> ExistPermission(int PermissionId, int systemId,string UserId);
    }
}
