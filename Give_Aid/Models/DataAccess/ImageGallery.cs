namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageGallery")]
    public partial class ImageGallery
    {
        [Key]
        public int ImageId { get; set; }

        [Required(ErrorMessage = "The Names must not be left blank")]
        [StringLength(250,MinimumLength =10,ErrorMessage = " Enter name at least 10 characters and no more than 250 characters")]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }
        
        [DefaultValue(0)]
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
