﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.RoleDtos
{
    public interface IRoleInfoDto
    {
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
    }
}
