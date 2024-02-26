using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemsDto
{
    public class SystemValidator : AbstractValidator<SystemInfoDto>
    {
        public SystemValidator()
        {
            Include(new BaseValidator());
        }
    }
}
