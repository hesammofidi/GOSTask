using Domain.Common;
namespace Domain
{
    public class SystemRolesPermission : BaseDomainEntity<int>
    {
        public Roles? Role { get; set; }
        public string? RoleId { get; set; }
        public Systems? System { get; set; }
        public int systemId { get; set; }
        public Permisions? Permission { get; set; }
        public int PermissionId { get; set; }
        public string? SystemName { get; set; }
        public string? PermissionName { get; set; }
        public string? RoleName { get; set; }
    }

}
