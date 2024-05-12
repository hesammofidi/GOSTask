using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDtos.Validators
{
    public class OrderValidator : AbstractValidator<IBaseOrderDto>
    {
        public OrderValidator()
        {
            RuleFor(o => o.Title).NotEmpty()
            .WithMessage("Title is required");
            RuleFor(o => o.PeopleId).NotEmpty()
              .WithMessage("People is required");
        }
    }
}
