using Application.Contract.Identity;
using MediatR;

namespace Application.Features.RoleFeatures.Commands
{
    public class DeleteRoleRequestHandlerCommand
    {
        public class DeleteRoleRequestCommand : IRequest
        {
            public string? RoleId { get; set; }
        }
        public class DeleteRoleHandlerCommand : IRequestHandler<DeleteRoleRequestCommand>
        {
            private readonly IRoleServices _roleService;
            public DeleteRoleHandlerCommand(IRoleServices roleService)
            {
                _roleService = roleService;
            }
            public async Task Handle(DeleteRoleRequestCommand request, CancellationToken cancellationToken)
            {
                await _roleService.DeleteRoleAsync(request.RoleId);
            }
        }
    }
}
