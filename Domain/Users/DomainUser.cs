﻿using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{

    [Auditable]
    public class DomainUser : IdentityUser
    {
        public string? FullName { get; set; }
        public ICollection<SystemUserRolePermission>? SystemUserRolePermission { get; set; }
        public ICollection<SystemRoleUser>? SystemRoleUser { get; set; }
        public ICollection<SystemUserPermission>? SystemUserPermission { get; set; }
    }
}
