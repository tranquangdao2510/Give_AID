using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Give_AID.Models.DataModels
{
    [Table("Fund")]
    public class Fund
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string FundId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string FundName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Description  { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string FundImg { get; set; }
        [Column(TypeName = "decimal")]
        public decimal TargetAmount  { get; set; }
        [Column(TypeName = "decimal")]
        public decimal CurentnAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public Category Category { get; set; }
        public Organization Organization { get; set; }
    }
}