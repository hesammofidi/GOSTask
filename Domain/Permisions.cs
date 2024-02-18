using Domain.Common;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Permisions : BaseDomainEntity<int>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<SystemPermission>? SystemPermision { get; set; }
        public ICollection<SystemRolesPermission>? SystemRolesPermission { get; set; }
        public ICollection<SystemUserRolePermission>? SystemUserRolePermission { get; set; }
        public ICollection<SystemUserPermission>? SystemUserPermission { get; set; }

    }
}
