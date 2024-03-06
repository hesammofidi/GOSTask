using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SRPDtos.Validators
{
    public class EditSRPValidator :AbstractValidator<EditSRPDto>
    {
        private readonly ISystemsRolesPermissionRepository _SRPRepository;
        public EditSRPValidator(ISystemsRolesPermissionRepository sRPRepository)
        {
            Include(new BaseSRPValidator());

            _SRPRepository = sRPRepository;
            RuleFor(o => new { o.systemId, o.PermissionId, o.RoleId, o.Id})
           .MustAsync(async (x, cancellation) =>
           {
               return !await _SRPRepository.ExistSRPInEdit(x.systemId, x.PermissionId, x.RoleId,x.Id);
           })
            .WithMessage("در حال حاضر نقش مورد نظر برای این سیستم موجود است");
        }
    }
}
