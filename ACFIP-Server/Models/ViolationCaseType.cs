using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP_Server.Models
{
    [Table("violation_case_violation_type")]
    public class ViolationCaseType
    {
        [Required]
        [ForeignKey(nameof(ViolationCase))]
        [Column("case_id", Order = 0)]
        public int CaseId { get; set; }
        public ViolationCase Case { get; set; }
        [Required]
        [ForeignKey(nameof(ViolationType))]
        [Column("type_id", Order = 1)]
        public int TypeId { get; set; }
        public ViolationType Type { get; set; }
    }
}
