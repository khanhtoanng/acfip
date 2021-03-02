using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP_Server.Models
{
    [Table("area")]
    public class Area
    {
        [Key]
        [Column("id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("name", Order = 1)]
        public string Name { get; set; }
        [Column("description", Order = 2)]
        public string Description { get; set; }
        [Required]
        [Column("deleted_flag")]
        public bool DeletedFlag { get; set; } = false;
        public ICollection<GroupCamera> GroupCameras { get; set; }
    }
}
