﻿using Order;
using Order.Collections.Generic;
using Order.Linq;
using Order.Text;
using Order.Threading.Tasks;

namespace Application.Dtos.CommonDtos
{
    public class FilterDataDto
    {
        public string? Filter { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string? Sort { get; set; }
    }
}
