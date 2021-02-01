using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ACFIP.Data.Models
{
    [Table("violation_type")]
    public partial class ViolationType
    {
        public ViolationType()
        {
            ViolationCaseTypes = new HashSet<ViolationCaseType>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(100)]
        public string Description { get; set; }

        [InverseProperty(nameof(ViolationCaseType.ViolationType))]
        public virtual ICollection<ViolationCaseType> ViolationCaseTypes { get; set; }
    }
}
