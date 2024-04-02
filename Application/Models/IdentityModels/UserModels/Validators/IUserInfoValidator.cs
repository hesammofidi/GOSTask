using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Models.IdentityModels.UserModels.Validators
{
    public class IUserInfoValidator : AbstractValidator<IUserInfoDto>
    {
        public IUserInfoValidator()
        {
            RuleFor(o=>o.UserName).NotEmpty()
                .WithMessage("لطفا نام کاربری را وارد کنید");

            RuleFor(o => o.FullName).NotEmpty()
               .WithMessage("لطفا نام کامل را وارد کنید");

            RuleFor(o => o.PhoneNumber).NotEmpty()
           .WithMessage("Please enter the phone number")
           .Must(phoneNumber =>
              {
                 if (phoneNumber.StartsWith("0"))
                  {
                    // If the phone number starts with 0, it should be 11 digits long.
                    return phoneNumber.Length == 11;
                   }
                  else if (phoneNumber.StartsWith("+"))
                   {
            // If the phone number starts with +, it should follow the international phone number format.
            // The length of phone numbers may vary from 7 digits to 15 digits.
            // For Iran (+98), it should not have 0 after 98 and should not be more than 10 digits after 98.
            if (phoneNumber.StartsWith("+98") && !phoneNumber.StartsWith("+980") && phoneNumber.Length <= 13)
            {
                return true;
            }
            else
            {
                // For other countries, we can use a regular expression to validate the phone number.
                // This is a simple validation and might need to be adjusted based on the specific rules for each country.
                return Regex.IsMatch(phoneNumber, @"^\+\d{7,15}$");
            }
        }
        else
        {
            // If the phone number does not start with 0 or +, it is invalid.
            return false;
        }
    })
           .WithMessage("شماره موبایل وارد شده معتبر نیست");


            RuleFor(o => o.Email).NotEmpty()
                .NotEmpty().WithMessage("لطفا ایمیل را وارد کنید")
                .EmailAddress().WithMessage("لطفا یک ایمیل معتبر وارد کنید");

        }
    }
}
