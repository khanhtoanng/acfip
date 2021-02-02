﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("camera_setting")]
    public partial class CameraSetting
    {
        public CameraSetting()
        {
            CameraConfigurations = new HashSet<CameraConfiguration>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("height")]
        public double? Height { get; set; }
        [Column("angle")]
        public double? Angle { get; set; }

        [InverseProperty("CameraSetting")]
        public virtual ICollection<CameraConfiguration> CameraConfigurations { get; set; }
    }
}
