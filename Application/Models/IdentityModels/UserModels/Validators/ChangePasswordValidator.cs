using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.IdentityModels.UserModels.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(o => o.Password).NotEmpty()
              .WithMessage("لطفا رمز عبور را وارد کنید");
            RuleFor(o => o.Id).NotEmpty()
             .WithMessage("UserId is require");
            RuleFor(o => o.ConfirmPassword).NotEmpty()
               .WithMessage("confirm password is require");
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password)
                 .WithMessage("Password and confirm password must match.");
        }
    }
}
