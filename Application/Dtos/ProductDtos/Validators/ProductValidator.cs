using FluentValidation;

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
