namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        public int SliderId { get; set; }
        [Required(ErrorMessage = "The title must not be vacated.")]
        [StringLength(250)]
        public string Title { get; set; }
        
        [Column(TypeName = "xml")]
        public string Image { get; set; }

        [Required(ErrorMessage = "the description must not be vacated.")]
        [StringLength(500)]
        [AllowHtml]
        public string Description { get; set; }

        public int? DisplayOrder { get; set; }

        [Required(ErrorMessage = "the url must not be vacated.")]
        [StringLength(250)]
        public string Url { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Status { get; set; }
    }
}
