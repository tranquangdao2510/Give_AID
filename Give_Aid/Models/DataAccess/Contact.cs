namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comtact")]
    public partial class Contact
    {
        [Key]
        public int IdMessage { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address. Example(abc@gmail.com)")]
        public string Email { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required(ErrorMessage = "Status  cannot be empty")]
        public bool? Status { get; set; }
        public Contact()
        {
            this.CreateDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
        }
    }
}
