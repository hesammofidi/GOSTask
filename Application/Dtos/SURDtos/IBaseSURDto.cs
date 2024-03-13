using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SURDtos
{
    public interface IBaseSURDto
    {
        public string? RoleId { get; set; }
        public int systemId { get; set; }
        public string? usersId { get; set; }

    }
}
