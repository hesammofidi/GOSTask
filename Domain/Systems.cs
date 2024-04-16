using Domain.Common;
using Domain.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Systems : BaseDomainEntity<int>
    {
      
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public ICollection<SystemRoles>? SystemRole { get; set; }
        public ICollection<SystemRoleUser>? SystemRoleUser { get; set; }
        public ICollection<SystemRolesPermission>? SystemRolesPermission { get; set; }
        public ICollection<SystemPermission>? SystemPermission { get; set; }
        public ICollection<SystemUserRolePermission>? SystemUserRolePermission { get; set; }
        public ICollection<SystemUserPermission>? SystemUserPermission { get; set; }

    }
}
