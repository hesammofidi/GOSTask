using System.ComponentModel.DataAnnotations;

namespace IdentityManagment.UI.Models.IdentityModels
{
    public class LoginRequestDto
    {
        [Display(Name = "Remember me?")]
        public bool IsPersistant { get; set; }

        /// <summary>
        /// The user's email address which acts as a user name.
        /// </summary>
        /// [Required]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";


    }
}
