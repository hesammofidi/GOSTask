using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.IdentityModels.UserModels
{
    public class AuthRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ReturnUrl { get; set; }
        public string? System { get; set; }
        public bool IsPersistant { get; set; }

    }
}
