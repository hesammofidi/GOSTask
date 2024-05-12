namespace Application.Models.IdentityModels.UserModels
{
    public class RessetPasswordDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Code { get; set; }
    }

}
