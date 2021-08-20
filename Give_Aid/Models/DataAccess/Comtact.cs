namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comtact")]
    public partial class Comtact
    {
        [Key]
        public int IdMessage { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Column(TypeName = "text")]
        public string Message { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
