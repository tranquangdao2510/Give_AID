namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donate")]
    public partial class Donate
    {
        public int DonateId { get; set; }

        public decimal? Amount { get; set; }
        [StringLength(200)]
        public string NameCrad { get; set; }
        [StringLength(200)]
        public string CradNumber { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool Status { get; set; }

        public int? PaymentId { get; set; }

        public int? CustomerId { get; set; }

        [StringLength(50)]
        public string FundId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Fund Fund { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
