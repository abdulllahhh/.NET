//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Facebook.Models
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int User_id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int Mobile { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Image { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<System.DateTime> Birthdate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}
