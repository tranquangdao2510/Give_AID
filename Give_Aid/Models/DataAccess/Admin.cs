namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Security;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int AdminId { get; set; }


        [Required(ErrorMessage = "The name must not be vacated.")]
        [StringLength(50)]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "The Email must not be vacated.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(250)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pasword cannot be vacated")]
        //[DataType(DataType.Password)]
        [StringLength(250, MinimumLength = 6, ErrorMessage = "The password must have at least 6 characters.")]
        //[RegularExpression("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,30})$" ,ErrorMessage = "Minimum eight and maximum 10 characters, at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "The address must not be vacated.")]
        [StringLength(250)]
        public string Address { get; set; }
        [Required(ErrorMessage = "The phone must not be vacated.")]
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        
        public DateTime? BirthDay { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Status { get; set; }
    }
}
