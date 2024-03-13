using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;

namespace Application.Dtos.SURPDtos.Validators
{
    public class EditSURPValidator : AbstractValidator<EditSURPDto>
    {
        private readonly ISystemsRolePermissionUsersRepository _SURPRepository;
        public EditSURPValidator(ISystemsRolePermissionUsersRepository sURPRepository)
        {
            Include(new SRUPBaseValidator());
            _SURPRepository = sURPRepository;
            RuleFor(o => new { o.PermissionId, o.systemId, o.RoleId,o.Id,o.usersId})
             .MustAsync(async (x, cancellation) =>
             {
                 return !await _SURPRepository.ExistSURPInEdit(x.PermissionId, x.systemId, x.RoleId,x.Id,x.usersId);
             })
             .WithMessage("دیتای وارد شده تکراری است");
        }
    }
}
