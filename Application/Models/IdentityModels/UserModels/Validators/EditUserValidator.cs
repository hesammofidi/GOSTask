using FluentValidation;

namespace Application.Models.IdentityModels.UserModels.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserDto>
    {

        public EditUserValidator()
        {
            Include(new IUserInfoValidator());

            RuleFor(o => o.Id).NotEmpty()
            .WithMessage("UserId is require");
            
        }
    }
}
