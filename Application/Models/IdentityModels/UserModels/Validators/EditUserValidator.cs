using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.IdentityModels.UserModels.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserDto>
    {
        public EditUserValidator()
        {
            Include(new IUserInfoValidator());

            RuleFor(o => o.UserId).NotEmpty()
            .WithMessage("UserId is require");
            
        }
    }
}
