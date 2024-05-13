using FluentValidation;

namespace Application.Dtos.OrderDtos.Validators
{
    public class EditOrderValidator : AbstractValidator<EditOrderDto>
    {
        public EditOrderValidator()
        {
            Include(new OrderValidator());
            RuleFor(o => o.Id).NotEmpty()
              .WithMessage("Id is required");
        }
    }
}
