using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives.Contract
{
    public interface IBaseDomainEntity
    {
        public string? Title { get; set; }
        DateTime InsertTime { get; set; }
        string? CreatedBy { get; set; }
        DateTime UpdateTime { get; set; }
        string? ModifiedBy { get; set; }
        DateTime? RemoveTime { get; set; }
        bool? IsRemoved { get; set; }

    }
}
