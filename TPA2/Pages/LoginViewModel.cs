using System.ComponentModel.DataAnnotations;

namespace TPA2.Pages
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Input text too long")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
