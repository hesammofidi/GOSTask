using Application.Contract.Identity;
using Application.Models.Abstraction;
using Domain.Users;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.IdentityModels.UserModels.Validators
{
    public class AddUserValidator : AbstractValidator<RegistrationRequest>
    {
        private readonly IAuthService _userService;
        private readonly UserManager<DomainUser> _userManager;

        public AddUserValidator(IAuthService userService, UserManager<DomainUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;

            Include(new IUserInfoValidator());

            RuleFor(x => x.UserName)
                .MustAsync(async (username, cancellation) =>
                {
                    var user = await _userManager.FindByNameAsync(username);
                    return user == null;
                })
                .WithMessage("User with this username already exists.");

            RuleFor(x => x.Email)
                .MustAsync(async (email, cancellation) =>
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    return user == null;
                })
                .WithMessage("User with this email already exists.");

            //RuleFor(x => x.PhoneNumber)
            //    .MustAsync(async (phoneNumber, cancellation) =>
            //    {
            //        var data = new FilterData { Filter = $"PhoneNumber eq {phoneNumber}" };
            //        var users = await _userService.FilterUserAsync(data);
            //        return !users.Items.Any();
            //    })
            //    .WithMessage("User with this phone number already exists.");


            RuleFor(o => o.Password).NotEmpty()
               .WithMessage("لطفا رمز عبور را وارد کنید");

            RuleFor(o => o.ConfirmPassword).NotEmpty()
               .WithMessage("confirm password is require");
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password)
                 .WithMessage("Password and confirm password must match.");
        }
    }

}
