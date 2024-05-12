using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SRPDtos.Validators
{
    public class AddSRPValidator : AbstractValidator<AddSRPDto>
    {
        private readonly ISystemsRolesProductsRepository _SRPRepository;

        public AddSRPValidator(ISystemsRolesProductsRepository sRPRepository)
        {
            _SRPRepository = sRPRepository;
            Include(new BaseSRPValidator());
           
            RuleFor(o => new { o.systemId, o.PermissionId, o.RoleId })
            .MustAsync(async (x, cancellation) =>
            {
                return !await _SRPRepository.ExistSRP(x.systemId, x.PermissionId, x.RoleId);
            })
             .WithMessage("دیتای وارد شده تکراری است");

        }
    }
}
