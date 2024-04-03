using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Persistance.SystemsRolesManagment
{
    public interface ISystemsRolesPermissionRepository : IGenericSqlRepository<SystemRolesPermission, int>
    {
        Task<bool> ExistSRP(int PermissionId, int systemId, string RoleId);
        Task<List<int>> GetPermissions(int systemId, string RoleId);
        Task<bool> ExistSRPInEdit(int PermissionId, int systemId, string RoleId, int Id);
    }
}
