using FluentValidation;

namespace Application.Dtos.RoleDtos.Validators
{
    public class AddRoleValidator : AbstractValidator<AddRoleDto>
    {
        public AddRoleValidator()
        {
            Include(new IRoleValidator());
        }
    }
}
