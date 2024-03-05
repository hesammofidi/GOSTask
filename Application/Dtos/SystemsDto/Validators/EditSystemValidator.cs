using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SystemsDto.Validators
{
    public class EditSystemValidator : AbstractValidator<EditSystemDto>
    {
        private readonly ISystemsRepository _systemsRepository;

        public EditSystemValidator(ISystemsRepository systemsRepository)
        {
            _systemsRepository = systemsRepository;
            Include(new BaseValidator());
          
            RuleFor(o => new { o.Title, o.Id})
          .MustAsync(async (x, cancellation) => !await _systemsRepository.ExistTitleInEdit(x.Title,x.Id))
          .WithMessage("Title must be unique");
        }
    }
}
