using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACFIP.Data.Models
{
    [Table("group_camera")]
    public class GroupCamera
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [Column("description", Order = 1)]
        public string Description { get; set; }
        [Required]
        [Column("deleted_flag", Order = 2)]
        public bool DeletedFlag { get; set; } = false;

        [ForeignKey(nameof(Area))]
        [Column("area_id", Order = 3)]
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public virtual List<Camera> Cameras{ get; set; }

    }
}
