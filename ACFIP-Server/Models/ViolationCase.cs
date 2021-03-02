using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP_Server.Models
{
    [Table("violation_case")]
    public class ViolationCase : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(GroupCamera))]
        [Column("group_cam_id", Order = 1)]
        public int GroupCamId { get; set; }
        public GroupCamera GroupCamera { get; set; }

        [Column("image_url", Order = 6)]
        public string ImgUrl { get; set; }
        [Column("video_url", Order = 7)]
        public string VideoUrl { get; set; }
    }
}
