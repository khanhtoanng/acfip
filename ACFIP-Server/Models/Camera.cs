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
        [Column("status", Order = 2)]
        public bool Status { get; set; } = false;
        [Required]
        [ForeignKey(nameof(Area))]
        [Column("area_id", Order = 3)]
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
