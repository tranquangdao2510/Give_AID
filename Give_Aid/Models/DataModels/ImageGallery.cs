using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Give_AID.Models.DataModels
{
    [Table("ImageGallery")]
    public class ImageGallery
    {
        [Key]
        public int ImageId { get; set; }
        [Column(TypeName ="xml")]
        public Xml MoreImage { get; set; }
        public int DisplayOrder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
    }
}