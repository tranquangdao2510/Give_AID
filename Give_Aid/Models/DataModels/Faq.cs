using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Give_AID.Models.DataModels
{
    [Table("Faq")]
    public class Faq
    {
        [Key]
        public int FaqId { get; set; }
        [Column(TypeName = "text")]
        public string question { get; set; }
        [Column(TypeName = "text")]
        public string answered { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
    }
}