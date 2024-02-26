using Application.Models.IdentityModels.UserModels.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.RoleDtos.Validators
{
    public class AddRoleValidator : AbstractValidator<AddRoleDto>
    {
        public AddRoleValidator()
        {
            Include(new IRoleValidator());
        }
    }
}
