using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Models.DataAccess
{
    [Table("About")]
    public partial class About
    {
        public int AboutId { get; set; }
        public string AboutImg { get; set; }
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }
        
        [AllowHtml]
        [Required(ErrorMessage = "Comtent cannot be empty")]
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Required(ErrorMessage = "Status cannot be empty")]
        public bool Status { get; set; }
    }
}