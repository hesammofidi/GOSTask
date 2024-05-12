using FluentValidation;

namespace Application.Dtos.RoleDtos.Validators
{
    public class IRoleValidator : AbstractValidator<IRoleInfoDto>
    {
        public IRoleValidator()
        {
            RuleFor(o => o.Name).NotEmpty()
                .WithMessage("Name is required");

            RuleFor(o => o.NormalizedName).NotEmpty()
               .WithMessage("NormalizedName is required");
        }
    }
}
