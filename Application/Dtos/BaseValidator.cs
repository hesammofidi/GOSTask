using Application.Dtos.CommonDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BaseValidator : AbstractValidator<IBaseDto>
    {
        public BaseValidator()
        {
            RuleFor(o => o.Title).NotEmpty()
              .WithMessage("Title is required");
        }
    }
}
