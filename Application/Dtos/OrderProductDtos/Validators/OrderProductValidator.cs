using FluentValidation;

namespace Application.Dtos.OrderProductDtos.Validators
{
    public class OrderProductValidator : AbstractValidator<IOrderProductDto>
    {
        public OrderProductValidator()
        {
            RuleFor(o => o.ProductId).NotEmpty()
           .WithMessage("Product is required");
            RuleFor(o => o.OrderId).NotEmpty()
              .WithMessage("Order is required");
        }
    }
}
