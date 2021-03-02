using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP_Server.Models
{
    [Table("camera_configuration")]
    public class CameraConfiguration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [Column("height", Order = 1)]
        public float Height { get; set; }
        [Column("angle", Order = 2)]
        public float Angle { get; set; }

    }
}
