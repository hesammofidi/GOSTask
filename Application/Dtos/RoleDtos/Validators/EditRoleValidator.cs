using FluentValidation;

namespace Application.Dtos.RoleDtos.Validators
{
    public class EditRoleValidator : AbstractValidator<EditRoleDto>
    {
        public EditRoleValidator()
        {
            Include(new IRoleValidator());
        }
        
    }
}
