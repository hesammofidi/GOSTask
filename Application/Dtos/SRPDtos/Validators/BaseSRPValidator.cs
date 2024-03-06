using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SRPDtos.Validators
{
    public class BaseSRPValidator : AbstractValidator<IBaseSRPDto>
    {
        public BaseSRPValidator()
        {
            RuleFor(o => o.systemId).NotEmpty()
           .WithMessage("System is required");
            RuleFor(o => o.SystemName).NotEmpty()
           .WithMessage("SystemId is required");
            RuleFor(o => o.RoleId).NotEmpty()
           .WithMessage("Role is required");
            RuleFor(o => o.RoleName).NotEmpty()
           .WithMessage("RoleName is required");
            RuleFor(o => o.PermissionId).NotEmpty()
            .WithMessage("Permission is required");
            RuleFor(o => o.PermissionName).NotEmpty()
            .WithMessage("PermissionName is required");
            RuleFor(o => o.PermissionId).NotEmpty()
              .WithMessage("Permission is required");
        }
    }
}
