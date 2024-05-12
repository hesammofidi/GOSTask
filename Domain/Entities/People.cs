using Domain.Common;

namespace Domain.Entities
{
    public class People : BaseDomainEntity<int>
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public ICollection<Orders>? Order { get; set; }
    }
}
