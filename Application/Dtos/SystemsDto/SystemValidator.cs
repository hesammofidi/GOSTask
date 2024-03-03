using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemsDto
{
    public class SystemValidator : AbstractValidator<SystemInfoDto>
    {
        private readonly ISystemsRepository _systemsRepository;
        public SystemValidator(ISystemsRepository systemsRepository)
        {
            Include(new BaseValidator());
            _systemsRepository = systemsRepository;
            RuleFor(o => o.Title)
          .NotEmpty().WithMessage("Title is required")
          .MustAsync(async (title, cancellation) => !await _systemsRepository.ExistTitle(title))
          .WithMessage("Title must be unique");
        }
    }
}
