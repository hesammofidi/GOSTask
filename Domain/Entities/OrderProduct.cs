using Domain.Common;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderProduct : BaseDomainEntity<int>
    {

        public Products? product { get; set; }
        public string? ProductId { get; set; }
        public Orders? Order { get; set; }
        public int OrderId { get; set; }
    }
}
