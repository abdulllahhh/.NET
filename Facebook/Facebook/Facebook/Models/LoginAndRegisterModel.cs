using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Facebook.Models
{
    public class RegisterModel
    {
        public int User_id { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your Gender")]
        public string Gender { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [DisplayName("Upload File")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Please select image ")]
        public Nullable<System.DateTime> Birthdate { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
    }
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string Message { get; set; }
        public string ReturnUrl { get; set; }
    }
}