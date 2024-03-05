using Application.Dtos.CommonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemRoleDtos
{
    public class SystemRoleDto : IBaseSurpDto
    {
        public int systemId { get; set; }
        public int Id { get; set; }
        public string RoleId { get; set; }
    }
}
