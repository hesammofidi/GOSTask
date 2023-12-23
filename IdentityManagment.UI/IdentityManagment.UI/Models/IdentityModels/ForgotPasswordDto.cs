using System.ComponentModel.DataAnnotations;

namespace IdentityManagment.UI.Models.IdentityModels
{
    public sealed class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
    }
}
