using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.RoleDtos.Validators
{
    public class EditRoleValidator : AbstractValidator<EditRoleDto>
    {
        public EditRoleValidator()
        {
            Include(new IRoleValidator());
        }
        
    }
}
