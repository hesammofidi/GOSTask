namespace IdentityManagment.UI.Models.IdentityModels
{
    public class LoginResponseDto
    {
        public string TokenType { get; } = "Bearer";

        public string? AccessToken { get; init; }

        public long? ExpiresIn { get; init; }

        
        public string? RefreshToken { get; init; }
    }
}
