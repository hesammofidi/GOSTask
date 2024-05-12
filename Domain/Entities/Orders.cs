using Domain.Common;

namespace Domain.Entities
{
    public class Orders : BaseDomainEntity<int>
    {
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public ICollection<OrderProduct>? OrderProduct { get; set; }
        public People? People { get; set; }
        public int PeopleId { get; set; }

    }
}
