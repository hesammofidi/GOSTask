using Domain.Common;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Products : BaseDomainEntity<int>
    {
        
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? Price { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }

    }
}
