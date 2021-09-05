namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Fund")]
    public partial class Fund
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fund()
        {
            Donates = new HashSet<Donate>();
        }
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string FundId { get; set; }

        [StringLength(250)]
        public string FundName { get; set; }
        [StringLength(250)]
        public string Title { get; set; }


        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public string Content { get; set; }

        [StringLength(500)]
        public string FundImg { get; set; }

        public decimal? TargetAmount { get; set; }

        public decimal? CurentAmount { get; set; }

        public int? CategoryId { get; set; }

        public int? OrganizationId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Status { get; set; }
        [StringLength(250)]
        public string MetaTitle { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donate> Donates { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
