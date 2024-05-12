using FluentValidation;

namespace Application.Dtos.PeopleDtos.Validators
{
    public class AddPeopleValidator : AbstractValidator<AddPeopleDto>
    {
      
        public AddPeopleValidator()
        {
            Include(new PeopleValidator());
        }
    }
}
