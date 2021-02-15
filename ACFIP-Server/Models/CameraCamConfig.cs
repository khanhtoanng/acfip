using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP_Server.Models
{
    [Table("camera_camera_configuration")]
    public class CameraCamConfig
    {
        [Required]
        [ForeignKey(nameof(Camera))]
        [Column("camera_id", Order = 0)]
        public int CameraId { get; set; }
        public Camera Camera { get; set; }
        [Required]
        [ForeignKey(nameof(CameraConfiguration))]
        [Column("configuration_id", Order = 1)]
        public int ConfigId { get; set; }
        public CameraConfiguration Config { get; set; }
        [Column("connection_string", Order = 3)]
        public string ConnectionString { get; set; }
    }
}
