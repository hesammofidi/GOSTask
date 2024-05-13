using Domain.Attributes;
using Microsoft.AspNetCore.Identity;

namespace Domain.Users
{

    [Auditable]
    public class DomainUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
