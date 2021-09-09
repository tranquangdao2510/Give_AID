namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageGallery")]
    public partial class ImageGallery
    {
        [Key]
        public int ImageId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public int? DisplayOrder { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public int? TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public bool Status { get; set; }
        [StringLength(250)]
        public string MetaTitle { get; set; }
    }
}
