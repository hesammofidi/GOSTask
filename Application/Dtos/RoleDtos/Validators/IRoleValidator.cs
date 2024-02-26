using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.RoleDtos.Validators
{
    public class IRoleValidator : AbstractValidator<IRoleInfoDto>
    {
        public IRoleValidator()
        {
            RuleFor(o => o.Name).NotEmpty()
                .WithMessage("Name is required");

            RuleFor(o => o.NormalizedName).NotEmpty()
               .WithMessage("NormalizedName is required");
        }
    }
}
