using Domain.Primitives.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseDomainEntity<TId> : IBaseDomainEntity, IEntity<TId>
    {
        public string? Title { get; set; }
        public DateTime InsertTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? RemoveTime { get; set; }
        public bool? IsRemoved { get; set; }
        public TId Id { get; set; }
    }
}
