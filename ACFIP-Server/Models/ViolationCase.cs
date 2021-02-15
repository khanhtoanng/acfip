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
        [ForeignKey(nameof(Camera))]
        [Column("camera_id", Order = 1)]
        public int CameraId { get; set; }
        public Camera Camera { get; set; }
        [Column("image_url", Order = 2)]
        public string ImgUrl { get; set; }
        [Column("video_url", Order = 3)]
        public string VideoUrl { get; set; }
    }
}
