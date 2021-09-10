namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Security;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Donates = new HashSet<Donate>();
        }
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "the Customer name cannot be vacated")]
        [StringLength(250)]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "The Email must not be vacated.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(200)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pasword cannot be vacated")]
        //[StringLength(50, MinimumLength = 6, ErrorMessage = "The password must have at least 6 characters.")]
        //[DataType(DataType.Password)]
        //[MembershipPassword(
        //    MinRequiredNonAlphanumericCharacters = 1,
        //    MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        //    ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
        //    MinRequiredPasswordLength = 6
        //)]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "The Address must not be vacated.")]
        [StringLength(250)]
        public string Address { get; set; }
        [Required(ErrorMessage = "The phone must not be vacated.")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        //[StringLength(50)]
        public string Phone { get; set; }
        public DateTime? BirthDay { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Status { get; set; }
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donate> Donates { get; set; }
    }
}
