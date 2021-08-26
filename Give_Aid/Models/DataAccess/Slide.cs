namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        public int SliderId { get; set; }

        [Column(TypeName = "xml")]
        public string Image { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Status { get; set; }
    }
}
