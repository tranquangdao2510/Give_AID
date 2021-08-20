using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Give_AID.Models.DataModels
{
    [Table("Partner")]
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string PartnersName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string Address { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string PartnersImg { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
    }
}