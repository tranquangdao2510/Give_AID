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

        [Required(ErrorMessage = "The Email must not be vacated.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Address cannot be empty")]

        public string Address { get; set; }


        [StringLength(200)]
        [Required(ErrorMessage = "The phone must not be vacated.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]


        public string Phone { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }
        public string MetaTitle { get; set; }
    }
}
