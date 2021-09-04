using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Give_Aid.Models.DataAccess;

namespace Give_Aid.Models.DAO
{
    public class ContactClientDao
    {
        [StringLength(50)]
        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address. Example(abc@gmail.com)")]
        public string Email { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }
        [StringLength(1000)]
        [Required(ErrorMessage = "Comments cannot be empty")]
        public string Message { get; set; }
        public IEnumerable<Contact> GetContacts { get; set; }
    }
}