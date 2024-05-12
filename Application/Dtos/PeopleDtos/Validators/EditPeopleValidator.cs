using FluentValidation;

namespace Application.Dtos.PeopleDtos.Validators
{
    public class EditPeopleValidator : AbstractValidator<EditPeopleDto>
    {
       
        public EditPeopleValidator()
        {
            Include(new PeopleValidator());

            RuleFor(o => o.Id).NotEmpty()
            .WithMessage("Id is required");

    }
}
