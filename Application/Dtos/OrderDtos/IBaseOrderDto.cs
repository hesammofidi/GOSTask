﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDtos
{
    public interface IBaseOrderDto
    {
        public string? Title { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int PeopleId { get; set; }

    }
}
