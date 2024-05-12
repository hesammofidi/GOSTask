using FluentValidation;

namespace Application.Dtos.ProductDtos.Validators
{
    public class AddProductValidator : AbstractValidator<AddProductDto>
    {

        public AddProductValidator()
        {
            Include(new ProductValidator());

        }
    }
}
