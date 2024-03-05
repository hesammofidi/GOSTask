using Application.Dtos.CommonDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BaseSRUpValidator : AbstractValidator<IBaseSurpDto>
    {
        public BaseSRUpValidator()
        {
            RuleFor(o => o.systemId).NotEmpty()
            .WithMessage("system is required");
        }
    }
}
