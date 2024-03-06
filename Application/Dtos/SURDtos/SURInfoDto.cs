using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SURDtos
{
    public class SURInfoDto : IBaseSURDto
    {
        public int Id { get; set; }
        public string? RoleId { get; set; }
        public int systemId { get; set; }
        public string? usersId { get; set; }
        public string? SystemName { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
    }
}
