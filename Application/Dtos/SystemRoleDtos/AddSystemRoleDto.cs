using Application.Dtos.CommonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemRoleDtos
{
    public class AddSystemRoleDto : IBaseSurpDto
    {
        public int systemId { get; set; }
        public string RoleId { get; set; }
    }
}
