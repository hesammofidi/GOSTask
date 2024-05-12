using FluentValidation;

namespace Application.Dtos.OrderProductDtos.Validators
{
    public class AddOrderProductValidator : AbstractValidator<AddOrderProductDto>
    {
      
        public AddOrderProductValidator()
        {
            Include(new OrderProductValidator());
        }
    }
}
