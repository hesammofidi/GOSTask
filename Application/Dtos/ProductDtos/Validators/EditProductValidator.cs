using Application.Contract.Persistance.OrdersRolesManagment;
using FluentValidation;

namespace Application.Dtos.ProductDtos.Validators
{
    public class EditProductValidator : AbstractValidator<EditProductDto>
    {
      

        public EditProductValidator(IProductsRepository ProductsRepository)
        {
            Include(new ProductValidator());
            RuleFor(o => o.Id).NotEmpty()
             .WithMessage("Id is required");
        }
    }
}
