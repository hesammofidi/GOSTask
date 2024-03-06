using Application.Dtos.CommonDtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SRPDtos
{
    public class AddSRPDto : IBaseSRPDto
    {
        public string? RoleId { get; set; }
        public int systemId { get; set; }
        public int PermissionId { get; set; }
        public string? SystemName { get; set; }
        public string? PermissionName { get; set; }
        public string? RoleName { get; set; }
    }
}
