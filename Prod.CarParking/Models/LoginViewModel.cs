using System.ComponentModel.DataAnnotations;

namespace Prod.CarParking.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User nanme must be provided.")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password must be provided.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
