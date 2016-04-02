using System.ComponentModel.DataAnnotations;

namespace Epam.Wunderlist.WebApp.ViewModels
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Put name")]
        [StringLength(20, ErrorMessage = "Should be less then 20 symbols.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Put email")]
        [StringLength(30, ErrorMessage = "Should be less then 30 symbols.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Put Password")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password should be 5-20 symbols.")]
        public string Password { get; set; }
    }
}