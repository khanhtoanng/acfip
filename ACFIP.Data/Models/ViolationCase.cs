using ACFIP.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("violation_case")]
    public class ViolationCase : BaseModel
    {
        public ViolationCase()
        {
            ViolationCaseTypes = new HashSet<ViolationCaseType>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [ForeignKey(nameof(Location))]
        [Column("location_id", Order = 1)]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [Column("image_url", Order = 2)]
        public string ImgUrl { get; set; }
        [Column("video_url", Order = 3)]
        public string VideoUrl { get; set; }
        [Column("status", Order = 4)]
        public int Status { get; set; } = AppConstants.ViolationStatus.DETECTED;
        [Column("guard_name", Order = 5)]
        public string GuardName { get; set; }
        public virtual ICollection<ViolationCaseType> ViolationCaseTypes { get; set; }
    }
}
