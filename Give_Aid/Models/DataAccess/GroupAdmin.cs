namespace Give_Aid.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("GroupAdmin")]
    public partial class GroupAdmin
    {
        
       [Key]
       [StringLength(20)]
       [Required(ErrorMessage = "The group id must not be vacated.")]
        public string  Id{ get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "The name must not be vacated.")]
        public string Name { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin> Admins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions{ get; set; }
    }
}