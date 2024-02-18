using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Auditable]
    public class Roles : IdentityRole
    {
        public ICollection<SystemRoles>? SystemRole { get; set; }
        public ICollection<SystemRoleUser>? SystemRoleUser { get; set; }
        public ICollection<SystemRolesPermission>? SystemRolesPermission { get; set; }
        public ICollection<SystemUserRolePermission>? SystemUserRolePermission { get; set; }
    }
}
