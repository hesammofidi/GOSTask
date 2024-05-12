using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderProductDtos
{
    public interface IOrderProductDto
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

    }
}
