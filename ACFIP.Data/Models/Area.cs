using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("area")]
    public partial class Area
    {
        public Area()
        {
            Camera = new HashSet<Camera>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("description")]
        [StringLength(100)]
        public string Description { get; set; }

        [InverseProperty("Area")]
        public virtual ICollection<Camera> Camera { get; set; }
    }
}
