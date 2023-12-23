using System.ComponentModel.DataAnnotations;

namespace IdentityManagment.UI.Models.IdentityModels
{
    public sealed class RessetPasswordRequestDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string ResetCode { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = "";

        }
}
