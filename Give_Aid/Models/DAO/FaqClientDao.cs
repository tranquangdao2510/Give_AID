using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Give_Aid.Models.DataAccess;

namespace Give_Aid.Models.DAO
{
    public class FaqClientDao
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Full Name cannot be empty")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address. Example(abc@gmail.com)")]
        public string Email { get; set; }
        [StringLength(1000)]
        [Required(ErrorMessage = "Question cannot be empty")]
        public string Question { get; set; }
        public IEnumerable<Faq> GetFaqs { get; set; }
        public IEnumerable<Partner> GetPartners { get; set; }
    }
}