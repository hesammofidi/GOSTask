using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SRPDtos
{
    public class SRPInfoDto
    {
        public int Id { get; set; }
        public string? RoleId { get; set; }
        public int systemId { get; set; }
        public int PermissionId { get; set; }
        public string? RoleName { get; set; }
        public string? PermissionName { get; set; }
        public string? SystemName { get; set; }

    }
}
