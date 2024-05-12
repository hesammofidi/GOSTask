using Application.Dtos.CommonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
