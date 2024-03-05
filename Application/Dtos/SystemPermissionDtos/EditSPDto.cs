using Application.Dtos.CommonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemPermissionDtos
{
    public class EditSPDto :IBaseSurpDto
    {
        public int PermissionId { get; set; }
        public int systemId { get; set; }
        public int Id { get; set; }
    }
}
