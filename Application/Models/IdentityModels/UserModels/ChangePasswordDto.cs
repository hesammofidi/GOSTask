namespace Application.Models.IdentityModels.UserModels
{
    public class ChangePasswordDto
    {
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Id { get; set; }
    }
}
