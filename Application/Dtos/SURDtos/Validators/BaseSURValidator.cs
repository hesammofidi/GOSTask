﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SURDtos.Validators
{
    public class SURPBaseValidator : AbstractValidator<IBaseSURDto>
    {
        public SURPBaseValidator()
        {
            RuleFor(o => o.systemId).NotEmpty()
            .WithMessage("System is required");
         
            RuleFor(o => o.RoleId).NotEmpty()
           .WithMessage("Role is required");

            RuleFor(o => o.usersId).NotEmpty()
            .WithMessage("User is required");
           
        }
    }
}
