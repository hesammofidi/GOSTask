using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.PermissionsDtos.Validators
{
    public class AddPermissionsValidator : AbstractValidator<AddPermissionDto>
    {
        private readonly IPermissionsRepository _permissionRepository;
        public AddPermissionsValidator(IPermissionsRepository permissionRepository)
        {
            Include(new BaseValidator());
            _permissionRepository = permissionRepository;
            RuleFor(o => o.Title)
          .NotEmpty().WithMessage("Title is required")
          .MustAsync(async (title, cancellation) => !await _permissionRepository.ExistTitle(title))
          .WithMessage("Title must be unique");
        }
    }
}
