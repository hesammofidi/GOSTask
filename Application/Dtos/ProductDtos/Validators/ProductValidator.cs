using Application.Dtos.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
