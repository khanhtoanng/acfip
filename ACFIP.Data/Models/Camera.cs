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
            CameraConfigurations = new HashSet<CameraConfiguration>();
            ViolationCases = new HashSet<ViolationCase>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("areaId")]
        public int? AreaId { get; set; }
        [Column("delFlg")]
        public int? DelFlg { get; set; }

        [ForeignKey(nameof(AreaId))]
        [InverseProperty("Cameras")]
        public virtual Area Area { get; set; }
        [InverseProperty("Camera")]
        public virtual ICollection<CameraConfiguration> CameraConfigurations { get; set; }
        [InverseProperty("Camera")]
        public virtual ICollection<ViolationCase> ViolationCases { get; set; }
    }
}
