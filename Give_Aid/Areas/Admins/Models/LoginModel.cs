using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Aid.Areas.Admins.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "name login must not be vacated.")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "Passwords must not be left blank")]
        public string Password { get; set; }

        public bool RemenberMe { get; set; }
    }
}