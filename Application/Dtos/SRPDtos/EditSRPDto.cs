using Application.Dtos.CommonDtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SRPDtos
{
    public class EditSRPDto : IBaseSRPDto
    {
        public int Id { get; set; }
        public string? RoleId { get; set; }
        public int systemId { get; set; }
        public int PermissionId { get; set; }

    }
}
