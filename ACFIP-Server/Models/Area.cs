using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP_Server.Models
{
    [Table("area")]
    public class Area : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [Column("description", Order = 1)]
        public string Description { get; set; }
        [Required]
        [Column("deleted_flag")]
        public bool DeletedFlag { get; set; } = false;
        public ICollection<Camera> Cameras { get; set; }
    }
}
