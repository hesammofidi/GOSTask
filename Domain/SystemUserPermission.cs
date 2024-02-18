using Domain.Common;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SystemUserPermission : BaseDomainEntity<int>
    {
        public Systems? System { get; set; }
        public int systemId { get; set; }
        public Users.DomainUser? users { get; set; }
        public string? usersId { get; set; }
        public Permisions? Permission { get; set; }
        public int PermissionId { get; set; }
        public string? SystemName { get; set; }
        public string? PermissionName { get; set; }
        public string? UserName { get; set; }
    }
}
