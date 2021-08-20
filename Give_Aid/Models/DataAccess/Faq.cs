namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faq")]
    public partial class Faq
    {
        public int FaqId { get; set; }

        [Column(TypeName = "text")]
        public string Question { get; set; }

        [Column(TypeName = "text")]
        public string Answered { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? Status { get; set; }
    }
}
