using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SURDtos.Validators
{
    public class AddSURValidator : AbstractValidator<AddSURDto>
    {
        private readonly ISystemsRoleUsersRepository _SURRepository;
        public AddSURValidator(ISystemsRoleUsersRepository sURRepository)
        {
            Include(new BaseSURValidator());
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
