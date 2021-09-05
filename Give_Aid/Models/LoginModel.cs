using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Aid.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Please enter your sign-in name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
    }
}