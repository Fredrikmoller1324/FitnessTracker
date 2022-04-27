using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Data.Models.Auth
{
    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm password must match")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
