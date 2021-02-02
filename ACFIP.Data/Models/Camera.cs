using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("camera")]
    public partial class Camera
    {
        public Camera()
        {
            CameraConfiguration = new HashSet<CameraConfiguration>();
            ViolationCase = new HashSet<ViolationCase>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("status")]
        [StringLength(100)]
        public string Status { get; set; }
        [Column("areaId")]
        public int? AreaId { get; set; }

        [ForeignKey(nameof(AreaId))]
        [InverseProperty("Camera")]
        public virtual Area Area { get; set; }
        [InverseProperty("Camera")]
        public virtual ICollection<CameraConfiguration> CameraConfiguration { get; set; }
        [InverseProperty("Camera")]
        public virtual ICollection<ViolationCase> ViolationCase { get; set; }
    }
}
