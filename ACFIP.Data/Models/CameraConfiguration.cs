using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("camera_configuration")]
    public class CameraConfiguration : BaseModel
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
