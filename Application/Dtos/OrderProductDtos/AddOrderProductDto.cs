using Application.Dtos.CommonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderProductDtos
{
    public class AddOrderProductDto : IOrderProductDto
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
