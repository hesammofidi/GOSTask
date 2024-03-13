using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SRPDtos
{
    public interface IBaseSRPDto 
    {
        public string? RoleId { get; set; }
        public int systemId { get; set; }
        public int PermissionId { get; set; }

    }
}
