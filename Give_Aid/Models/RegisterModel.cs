using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Give_Aid.Models
{
    public class RegisterModel
    {
        [Key]
        public int Customerid { get; set; }
        [Required(ErrorMessage = "Sing-in name cannot be empty")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Pasword cannot be vacated")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The password must have at least 6 characters.")]
        [MembershipPassword(
            MinRequiredNonAlphanumericCharacters = 1,
            MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
            ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
            MinRequiredPasswordLength = 6
        )]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password cannot be vacated")]
        [Compare("Password", ErrorMessage = "Incorrect password")]

        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "The name must not be vacated.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The address must not be vacated.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The Email must not be vacated.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The phone must not be vacated.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
    }
}