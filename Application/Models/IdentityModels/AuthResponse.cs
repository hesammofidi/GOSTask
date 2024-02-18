using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.IdentityModels
{
    public class AuthResponse
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string TokenType { get; } = "Bearer";

        public string? AccessToken { get; init; }

        public long? ExpiresIn { get; init; }

        public string? RefreshToken { get; init; }

    }
}
