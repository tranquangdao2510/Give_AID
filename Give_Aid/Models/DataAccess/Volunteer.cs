namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Volunteer")]
    public partial class Volunteer
    {
        [Key]
        public int VolunteersId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Name cannot be empty")]
        public string VolunteersName { get; set; }

        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Invalid Email Address. Example(abc@gmail.com)")]
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Image { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "BirthDay date cannot be empty")]
        public DateTime? BirthDay { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }
        [StringLength(250)]
        public string MetaTitle { get; set; }
        public Volunteer()
        {
            this.CreateDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }
    }
}
