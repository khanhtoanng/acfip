using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("violation_case")]
    public class ViolationCase 
    {
        public ViolationCase()
        {
            ViolationCaseTypes = new HashSet<ViolationCaseType>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Camera))]
        [Column("camera_id", Order = 1)]
        public int CameraId { get; set; }
    
        public Camera Camera { get; set; }
        [Column("image_url", Order = 2)]
        public string ImgUrl { get; set; }
        [Column("video_url", Order = 3)]
        public string VideoUrl { get; set; }
        [Required]
        [Column("created_time")]
        public DateTime CreatedTime { get; set; }
        public virtual ICollection<ViolationCaseType> ViolationCaseTypes { get; set; }
    }
}
