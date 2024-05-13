using FluentValidation;

namespace Application.Dtos.OrderProductDtos.Validators
{
    public class EditOrderProductValidator : AbstractValidator<EditOrderProductDto>
    {
        
        public EditOrderProductValidator()
        {
            Include(new OrderProductValidator());
        }
    }
}
