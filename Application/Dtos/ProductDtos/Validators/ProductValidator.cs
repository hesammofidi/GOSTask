using Application.Dtos.ProductDtos;
using FluentValidation;
using Order;
using Order.Collections.Generic;
using Order.Linq;
using Order.Text;
using Order.Threading.Tasks;

namespace Application.Dtos.ProductDtos.Validators
{
    public class ProductValidator : AbstractValidator<IBaseProductDto>
    {
        public ProductValidator()
        {
            RuleFor(o => o.Title).NotEmpty()
              .WithMessage("Title is required");
            RuleFor(o => o.Price).NotEmpty()
              .WithMessage("Price is required");
        }
    }
}
