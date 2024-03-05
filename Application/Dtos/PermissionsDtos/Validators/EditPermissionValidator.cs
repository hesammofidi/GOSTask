using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.PermissionsDtos.Validators
{
    public class EditPermissionValidator : AbstractValidator<EditPermissionDto>
    {
        private readonly IPermissionsRepository _permissionRepository;

        public EditPermissionValidator(IPermissionsRepository permissionRepository)
        {
            Include(new BaseValidator());
            _permissionRepository = permissionRepository;
            RuleFor(o => new { o.Title , o.Id })
          
          .MustAsync(async (x, cancellation) => !await _permissionRepository.ExistTitleInEdit(x.Title,x.Id))
          .WithMessage("Title must be unique");
        }
    }
}
