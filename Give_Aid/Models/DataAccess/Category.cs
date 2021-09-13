namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Funds = new HashSet<Fund>();
        }
        [Key]
        public int CategoryId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "CategoryName cannot be empty")]
        public string CategoryName { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Required(ErrorMessage = "Status cannot be empty")]
        public bool Status { get; set; }
        [StringLength(250)]
        public string MetaTitle { get; set; }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fund> Funds { get; set; }
    }
}
