using System.ComponentModel.DataAnnotations;

namespace IdentityManagment.UI.Models.IdentityModels
{
    public class RegisterRequestDto
    {
        /// <summary>
        /// The user's email address which acts as a user name.
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }
}
