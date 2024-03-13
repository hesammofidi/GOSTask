using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SURPDtos
{
    public class ExistPermissionDto
    {
        public int systemId { get; set; }
        public string? usersId { get; set; }
        public string? PermissionName { get; set; }
    }
}
