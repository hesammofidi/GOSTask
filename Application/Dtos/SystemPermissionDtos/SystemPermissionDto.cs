using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemPermissionDtos
{
    public class SystemPermissionDto
    {
        public int PermissionId { get; set; }
        public int systemId { get; set; }
        public string? SystemName { get; set; }
        public string? PermissionName { get; set; }
        public int Id { get; set; }
    }
}
