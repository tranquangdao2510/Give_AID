using Give_Aid.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Aid.Models
{
    public class DonateViewModel
    {
        [Key]
        public int Id { get; set; }
        public int PaymentID { get; set; }
        public string FundId { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Fund Fund { get; set; }

        public virtual Payment Payment { get; set; }
    }
}