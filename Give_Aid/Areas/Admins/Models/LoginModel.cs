using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Aid.Areas.Admins.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = " ban vui long nhap ten")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = " ban vui long nhap mat khau")]
        public string Password { get; set; }

        public bool RemenberMe { get; set; }
    }
}