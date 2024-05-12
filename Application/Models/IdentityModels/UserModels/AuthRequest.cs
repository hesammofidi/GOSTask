namespace Application.Models.IdentityModels.UserModels
{
    public class AuthRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool IsPersistant { get; set; }

    }
}
