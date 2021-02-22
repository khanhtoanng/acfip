using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP_Server.Models
{
    [Table("camera")]
    public class Camera : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [Required]
        [Column("name", Order = 1)]
        public string Name { get; set; }
        [Required]
        [Column("is_active", Order = 2)]
        public bool IsActive { get; set; } = false;
        [ForeignKey(nameof(Area))]
        [Column("area_id", Order = 3)]
        public int? AreaId { get; set; }
        public Area Area { get; set; }
        [Column("connection_string", Order = 4)]
        public string ConnectionString { get; set; }
        [Required]
        [ForeignKey(nameof(CameraConfiguration))]
        [Column("configuration_id", Order = 5)]
        public int ConfigId { get; set; }
        [Required]
        [Column("deleted_flag")]
        public bool DeletedFlag { get; set; } = false;
        public CameraConfiguration Config { get; set; }
    }
}
