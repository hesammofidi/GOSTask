using Application.Contract.Persistance.SystemsRolesManagment;
using FluentValidation;

namespace Application.Dtos.SURPDtos.Validators
{
    public class AddSURPValidator : AbstractValidator<AddSURPDto>
    {
        private readonly ISystemsRolePermissionUsersRepository _SURPRepository;
        public AddSURPValidator(ISystemsRolePermissionUsersRepository sURPRepository)
        {
            Include(new SRUPBaseValidator());
            _SURPRepository = sURPRepository;
            RuleFor(o => new { o.PermissionId, o.systemId, o.RoleId, o.usersId })
           .MustAsync(async (x, cancellation) =>
           {
               return !await _SURPRepository.ExistSURP(x.PermissionId, x.systemId, x.RoleId, x.usersId);
           })
           .WithMessage("دیتای وارد شده تکراری است");
        }
    }
}
