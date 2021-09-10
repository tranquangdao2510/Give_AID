namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donate")]
    public partial class Donate
    {
        [Key]
        public int DonateId { get; set; }
        [Required(ErrorMessage = "The amount must not be vacated.")]
        public decimal? Amount { get; set; }
        [Required(ErrorMessage = "The card name must not be vacated.")]
        [StringLength(200, ErrorMessage = "The card name must not exceed 200 characters")]
        public string NameCard { get; set; }
        [Required(ErrorMessage = "The card number must not be vacated.")]
        [StringLength(200, MinimumLength = 12, ErrorMessage = "The card number must have at least 12 characters.")]
        public string CardNumber { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool Status { get; set; }

        public int? PaymentId { get; set; }
        public int? CustomerId { get; set; }

        [StringLength(50)]
        public string FundId { get; set; }
        
        [Required(ErrorMessage = "The content must not be vacated.")]
        [StringLength(500)]
        public string Content { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Fund Fund { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
