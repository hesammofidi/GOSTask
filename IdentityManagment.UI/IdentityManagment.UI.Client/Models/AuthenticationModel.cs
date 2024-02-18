namespace IdentityManagment.UI.Client.Models
{
    public class AuthenticationModel
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string? UserName { get; set; }
    }
}
