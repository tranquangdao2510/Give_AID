using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Aid.Models
{
    public class RegisterModel
    {
        //[Display(Name="")]
        [Key]
        public int Customerid { get; set; }
        [Required(ErrorMessage = "Sing-in name cannot be empty")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Pasword cannot be vacated")]
        [StringLength(50,MinimumLength =6,ErrorMessage = "The password must have at least 6 characters.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password cannot be vacated")]
        [Compare("Password",ErrorMessage = "Incorrect password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "The name must not be vacated.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The address must not be vacated.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The Email must not be vacated.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The phone must not be vacated.")]
        public string Phone { get; set; }
    }
}