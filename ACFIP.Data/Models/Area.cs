using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("area")]
    public partial class Area : BaseModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [Column("name", Order =1)]
        public string Name { get; set; }
        [Column("description", Order = 2)]
        public string Description { get; set; }
        public virtual ICollection<Camera> Cameras { get; set; }
    }
}
