using System.ComponentModel.DataAnnotations;

namespace Facebook.Models
{
    public class Login2Model
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string Message { get; set; }
    }
}