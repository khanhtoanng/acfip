using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("violation_case_type")]
    public partial class ViolationCaseType
    {
        [Key]
        [Column("violation_type_id")]
        public int ViolationTypeId { get; set; }
        [Key]
        [Column("violation_case_id")]
        public int ViolationCaseId { get; set; }

        [ForeignKey(nameof(ViolationCaseId))]
        [InverseProperty("ViolationCaseType")]
        public virtual ViolationCase ViolationCase { get; set; }
        [ForeignKey(nameof(ViolationTypeId))]
        [InverseProperty("ViolationCaseType")]
        public virtual ViolationType ViolationType { get; set; }
    }
}
