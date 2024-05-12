using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;

namespace Application.Dtos.SURDtos.Validators
{
    public class AddSURValidator : AbstractValidator<AddSURDto>
    {
        private readonly IPeopleRepository _SURRepository;
        public AddSURValidator(IPeopleRepository sURRepository)
        {
            Include(new SURPBaseValidator());
            _SURRepository = sURRepository;
            RuleFor(o => new { o.usersId, o.systemId, o.RoleId })
                .MustAsync(async (x, cancellation) =>
                {
                    return !await _SURRepository.ExistSRU(x.usersId, x.systemId, x.RoleId);
                })
                .WithMessage("دیتای وارد شده تکراری است");
        }
    }
}
