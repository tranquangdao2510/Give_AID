namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tag()
        {
            Blogs = new HashSet<Blog>();
            this.CreateDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }

        public int TagId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "name cannot be empty")]
        public string TagName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Required(ErrorMessage = "Status  cannot be empty")]
        public bool? Status { get; set; }
        [StringLength(250)]
        public string MetaTitle { get; set; }
        public int? DisplayOrder{ get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog> Blogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageGallery> ImageGalleries { get; set; }
    }
}
