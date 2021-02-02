using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("camera_configuration")]
    public partial class CameraConfiguration
    {
        [Key]
        [Column("camera_id")]
        public int CameraId { get; set; }
        [Key]
        [Column("camera_setting_id")]
        public int CameraSettingId { get; set; }
        [Column("connection_url")]
        [StringLength(100)]
        public string ConnectionUrl { get; set; }

        [ForeignKey(nameof(CameraId))]
        [InverseProperty("CameraConfigurations")]
        public virtual Camera Camera { get; set; }
        [ForeignKey(nameof(CameraSettingId))]
        [InverseProperty("CameraConfigurations")]
        public virtual CameraSetting CameraSetting { get; set; }
    }
}
