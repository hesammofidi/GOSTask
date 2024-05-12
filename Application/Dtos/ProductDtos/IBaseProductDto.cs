using Order;
using Order.Collections.Generic;
using Order.Linq;
using Order.Text;
using Order.Threading.Tasks;

namespace Application.Dtos.ProductDtos
{
    public interface IBaseProductDto
    {
        public int? Price { get; set; }
        public string? Title { get; set; }
    }
}
