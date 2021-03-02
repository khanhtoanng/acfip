using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Models
{
    [Table("group_camera")]
    public class GroupCamera
    {
        [Column("group_id", Order = 0)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("description", Order = 1)]
        public string Description { get; set; }
        [Required]
        [Column("area_id", Order = 2)]
        [ForeignKey(nameof(Area))]
        public int AreaId { get; set; }
        public Area Area { get; set; }
        [Required]
        [Column("deleted_flag", Order = 3)]
        public bool DeletedFlag { get; set; } = false;
        public ICollection<Camera> Cameras { get; set; }
    }
}
