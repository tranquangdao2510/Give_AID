using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Give_AID.Models.DataModels
{
    [Table("Donate")]
    public class Donate
    {
        [Key]
        public int DonateId { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}