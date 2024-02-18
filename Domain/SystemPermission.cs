using Domain.Common;

namespace Domain
{
    public class SystemPermission : BaseDomainEntity<int>
    {
        public Permisions? Permission { get; set; }
        public int PermissionId { get; set; }
        public Systems? System { get; set; }
        public int systemId { get; set; }
        public ICollection<SystemRolesPermission>? SystemRolesPermission { get; set; }
    }
}
