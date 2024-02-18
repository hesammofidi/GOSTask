using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SystemRoles : BaseDomainEntity<int>
    {
        public Roles? Role { get; set; }
        public string? RoleId { get; set; }
        public Systems? System { get; set; }
        public int systemId { get; set; }
        public ICollection<SystemRolesPermission>? SystemRolesPermission { get; set; }
        public ICollection<SystemUserRolePermission>? SystemUserRolePermission { get; set; }
    }
}
