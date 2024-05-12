using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;

namespace Application.Dtos.ProductDtos.Validators
{
    public class EditProductValidator : AbstractValidator<EditProductDto>
    {
      

        public EditProductValidator(IProductsRepository ProductsRepository)
        {
            Include(new ProductValidator());
        }
    }
}
