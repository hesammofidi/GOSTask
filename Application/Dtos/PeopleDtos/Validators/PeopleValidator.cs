using FluentValidation;

namespace Application.Dtos.PeopleDtos.Validators
{
    public class PeopleValidator : AbstractValidator<IPeopleDto>
    {
        public PeopleValidator()
        {
            RuleFor(o => o.Email).NotEmpty()
               .NotEmpty().WithMessage("لطفا ایمیل را وارد کنید")
               .EmailAddress().WithMessage("لطفا یک ایمیل معتبر وارد کنید");

            RuleFor(o => o.FullName).NotEmpty()
              .WithMessage("FullName is required");
        }
    }
}
