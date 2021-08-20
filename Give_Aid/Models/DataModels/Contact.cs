using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Give_AID.Models.DataModels
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int IdMessage { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(20)]
        public string Phone { get; set; }
        [Column(TypeName = "text")]
        public string Message { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string FirtName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string Email { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string Address { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
    }
}