namespace Application.Models.IdentityModels.UserModels
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
