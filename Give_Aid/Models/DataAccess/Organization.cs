namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Organization")]
    public partial class Organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organization()
        {
            Funds = new HashSet<Fund>();
        }

        public int OrganizationId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Name cannot be empty")]
        public string OrganizationName { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Address cannot be empty")]

        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phone cannot be empty")]

        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Required(ErrorMessage = "Status cannot be empty")]

        public bool Status { get; set; }
        public string MetaTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fund> Funds { get; set; }
    }
}
