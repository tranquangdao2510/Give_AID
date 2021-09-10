namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partner")]
    public partial class Partner
    {
        [Key]
        public int PartnerId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Name cannot be empty")]

        public string PartnerName { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Email cannot be empty")]

        public string Email { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Address cannot be empty")]

        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phone cannot be empty")]

        public string Phone { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Required(ErrorMessage = "Status cannot be empty")]
        public bool Status { get; set; }
        public string MetaTitle { get; set; }
    }
}
