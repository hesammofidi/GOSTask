using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.SRPDtos.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SURDtos.Validators
{
    public class EditSURValidator : AbstractValidator<EditSURDto>
    {
        private readonly ISystemsRoleUsersRepository _SURRepository;
        public EditSURValidator(ISystemsRoleUsersRepository sURRepository)
        {
            Include(new SURPBaseValidator());
            _SURRepository = sURRepository;
            RuleFor(o => new { o.usersId, o.systemId, o.RoleId,o.Id})
                 .MustAsync(async (x, cancellation) =>
                 {
                     return !await _SURRepository.ExistSRUInEdit(x.usersId, x.systemId, x.RoleId,x.Id);
                 })
                 .WithMessage("دیتای وارد شده تکراری است");
        }
    }
}
