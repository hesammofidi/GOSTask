namespace Application.Models.IdentityModels.UserModels
{
    public interface IUserInfoDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; } 

    }
}
