using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SURDtos.Validators
{
    public class BaseSURValidator : AbstractValidator<IBaseSURDto>
    {
        public BaseSURValidator()
        {
            RuleFor(o => o.systemId).NotEmpty()
         .WithMessage("System is required");
            RuleFor(o => o.SystemName).NotEmpty()
           .WithMessage("SystemId is required");
            RuleFor(o => o.RoleId).NotEmpty()
           .WithMessage("Role is required");
            RuleFor(o => o.RoleName).NotEmpty()
           .WithMessage("RoleName is required");
            RuleFor(o => o.usersId).NotEmpty()
            .WithMessage("Permission is required");
            RuleFor(o => o.UserName).NotEmpty()
            .WithMessage("PermissionName is required");
           
        }
    }
}
