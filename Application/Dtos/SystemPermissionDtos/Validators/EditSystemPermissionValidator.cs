using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemPermissionDtos.Validators
{
    public class EditSystemPermissionValidator : AbstractValidator<EditSPDto>
    {
        private readonly ISystemsPermissionsRepository _systemsPermissionRepository;
        public EditSystemPermissionValidator(ISystemsPermissionsRepository systemsPermissionRepository)
        {
            Include(new BaseSRUpValidator());
            _systemsPermissionRepository = systemsPermissionRepository;

            RuleFor(o => o.PermissionId).NotEmpty()
            .WithMessage("Permission is required");

            RuleFor(o => new { o.systemId, o.PermissionId, o.Id})
            .MustAsync(async (x, cancellation) =>
            {
                return !await _systemsPermissionRepository.ExistSystempermissionInEdit(x.systemId, x.PermissionId,x.Id);
            })
               .WithMessage("در حال حاضر نقش مورد نظر برای این سیستم موجود است");
        }
    }
}
