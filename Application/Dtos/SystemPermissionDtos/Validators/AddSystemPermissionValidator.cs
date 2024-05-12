using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemPermissionDtos.Validators
{
    public class AddSystemPermissionValidator : AbstractValidator<AddSPDto>
    {
        private readonly IOrderPeopleRepository _systemsProductsRepository;
        public AddSystemPermissionValidator(IOrderPeopleRepository systemsProductsRepository)
        {
            _systemsProductsRepository = systemsProductsRepository;
            Include(new BaseSRUpValidator());

            RuleFor(o => o.PermissionId).NotEmpty()
            .WithMessage("Permission is required");

            RuleFor(o => new { o.systemId, o.PermissionId })
            .MustAsync(async (x, cancellation) =>
            {
                return !await _systemsProductsRepository.ExistSystemPermission(x.systemId, x.PermissionId);
            })
               .WithMessage("در حال حاضر نقش مورد نظر برای این سیستم موجود است");
           
        }
    }
}
