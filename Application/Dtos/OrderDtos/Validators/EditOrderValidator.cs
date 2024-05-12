using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.OrderDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDtos.Validators
{
    public class EditOrderValidator : AbstractValidator<EditOrderDto>
    {
        public EditOrderValidator()
        {
            Include(new OrderValidator());
            RuleFor(o => o.Id).NotEmpty()
              .WithMessage("Id is required");
        }
    }
}
