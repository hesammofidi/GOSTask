using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemRoleDtos.Validators
{
    public class EditSystemRoleValidator : AbstractValidator<EditSystemRoelDto>
    {
        private readonly ISystemsRolesRepository _systemsRolesRepository;
        public EditSystemRoleValidator(ISystemsRolesRepository systemsRolesRepository)
        {
            Include(new BaseSRUpValidator());
            _systemsRolesRepository = systemsRolesRepository;
            RuleFor(o => o.RoleId).NotEmpty()
           .WithMessage("Role is required");

            RuleFor(o => new { o.RoleId, o.systemId, o.Id })
                .MustAsync(async (x, cancellation) =>
                {
                    return !await _systemsRolesRepository.ExistSystemRoleInEdit(x.systemId, x.RoleId, x.Id);
                })
                .WithMessage("در حال حاضر نقش مورد نظر برای این سیستم موجود است");

        }
    }
}
