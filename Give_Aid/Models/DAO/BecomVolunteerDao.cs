using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Aid.Models.DAO
{
    public class BecomVolunteerDao
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Full Name cannot be empty")]
        public string FullName { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address. Example(abc@gmail.com)")]
        public string Email { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }
        [StringLength(500)]
        [Required(ErrorMessage = "Image cannot be empty")]
        public string Image { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Refrence Contact cannot be empty")]
        public string RefrenceContact { get; set; }  
        [StringLength(1000)]
        [Required(ErrorMessage = "Comments cannot be empty")]
        public string Message { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "BirthDay date cannot be empty")]
        public DateTime? BirthDay { get; set; }
        public IEnumerable<Contact> GetContacts { get; set; }
        public IEnumerable<Partner> GetPartners { get; set; }
    }
}