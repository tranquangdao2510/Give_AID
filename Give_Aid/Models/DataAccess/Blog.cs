namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int BlogId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }

        [StringLength(500)]
        public string BlogImage { get; set; }
        [Required(ErrorMessage = "Tag cannot be empty")]
        public int? TagId { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Content cannot be empty")]
        public string Content { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Created date cannot be empty")]
        public DateTime? CreateDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedDate { get; set; }
        [Required(ErrorMessage = "Status cannot be empty")]
        public bool? Status { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
