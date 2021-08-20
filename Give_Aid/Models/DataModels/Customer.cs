using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Give_AID.Models.DataModels
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string Email { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string PassWord { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string Address { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDay { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
    }
}