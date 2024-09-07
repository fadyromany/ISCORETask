using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ISCORETask.DTOs.Request
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "incomplete.parameter")]
        public string Username { get; set; }
        [Required(ErrorMessage = "incomplete.parameter")]
        public string Email { get; set; }
        [Required(ErrorMessage = "incomplete.parameter")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "incomplete.parameter")]
        [PasswordPropertyText(true)]
        public string Password { get; set; }

    }
}
