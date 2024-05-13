using Application.Contract.Persistance.EFCore;
using FluentValidation;

namespace Application.Dtos.ProductDtos.Validators
{
    public class EditProductValidator : AbstractValidator<EditProductDto>
    {
        public EditProductValidator()
        {
            Include(new ProductValidator());
            RuleFor(o => o.Id).NotEmpty()
             .WithMessage("Id is required");
        }
    }
}
