using Domain.Common;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SystemRoleUser : BaseDomainEntity<int>
    {
        public Roles? Role { get; set; }
        public string? RoleId { get; set; }
        public Systems? System { get; set; }
        public int systemId { get; set; }
        public Users.DomainUser? users { get; set; }
        public string? usersId { get; set; }
    }
}
