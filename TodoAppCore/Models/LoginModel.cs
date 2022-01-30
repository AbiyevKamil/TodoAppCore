using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoAppCore.Models
{
    public class LoginModel
    {
        [Required, DisplayName("Username"), DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Required, DisplayName("Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
