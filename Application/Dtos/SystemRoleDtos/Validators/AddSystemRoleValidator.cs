using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemRoleDtos.Validators
{
    public class AddSystemRoleValidator : AbstractValidator<AddSystemRoleDto>
    {
        private readonly ISystemsRolesRepository _systemsRolesRepository;
        public AddSystemRoleValidator(ISystemsRolesRepository systemsRolesRepository)
        {
            Include(new BaseSRUpValidator());
            _systemsRolesRepository = systemsRolesRepository;
            RuleFor(o => o.RoleId).NotEmpty()
            .WithMessage("Role is required");

            RuleFor(o => new { o.systemId, o.RoleId })
                .MustAsync(async (x, cancellation) =>
                {
                    return !await _systemsRolesRepository.ExistSystemRole(x.systemId, x.RoleId);
                })
                .WithMessage("در حال حاضر نقش مورد نظر برای این سیستم موجود است");
        }
    }
}
