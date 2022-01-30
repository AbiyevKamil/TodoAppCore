using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoAppCore.Models
{
    public class RegisterModel
    {
        [Required, DisplayName("Username"), DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Required, DisplayName("Password"), DataType(DataType.Password), MinLength(6, ErrorMessage = "Password must contain minimum 6 characters.")]
        public string Password { get; set; }
        [Required, DisplayName("Password"), DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Passwords don't match. ")]
        public string RePassword { get; set; }
    }
}
