using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.PermissionsDtos
{
    public class PermissionsValidator : AbstractValidator<PermissionInfoDto>
    {
        public PermissionsValidator()
        {
            Include(new BaseValidator());
        }
    }
}
