using FluentValidation;

namespace Application.Dtos.OrderDtos.Validators
{
    public class AddOrderValidator : AbstractValidator<AddOrderDto>
    {
        
        public AddOrderValidator()
        {
            Include(new OrderValidator());
        }
    }
}
