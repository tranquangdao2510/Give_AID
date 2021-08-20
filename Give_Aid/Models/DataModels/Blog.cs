using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Give_AID.Models.DataModels
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(100)]
        public string Title { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string BlogImage { get; set; }
        [Column(TypeName = "text")]
        public string Content { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}