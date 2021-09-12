namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Faq")]
    public partial class Faq
    {
        public int FaqId { get; set; }

        [Required(ErrorMessage = "Question cannot be empty")]

        public string Question { get; set; }


        [Required(ErrorMessage = "Answered cannot be empty")]
        [AllowHtml]
        public string Answered { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        [Required(ErrorMessage = "Status cannot be empty")]
        public bool Status { get; set; }
        public string MetaTitle { get; set; }
    }
}
