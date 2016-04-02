using System.ComponentModel.DataAnnotations;

namespace Epam.Wunderlist.WebApp.ViewModels
{
    public class UserLoginModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Field can't be empty!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field can't be empty!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}