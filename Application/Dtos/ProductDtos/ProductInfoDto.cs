using Application.Dtos.CommonDtos;
using Order;
using Order.Collections.Generic;
using Order.Linq;
using Order.Text;
using Order.Threading.Tasks;

namespace Application.Dtos.ProductDtos
{
    public class ProductInfoDto : IBaseDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? Price { get; set; }
    }
}
