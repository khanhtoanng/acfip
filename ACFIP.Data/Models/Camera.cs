﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

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
        [StringLength(100)]
        public string Status { get; set; }
        [Column("areaId")]
        public int? AreaId { get; set; }

        [ForeignKey(nameof(AreaId))]
        [InverseProperty("Cameras")]
        public virtual Area Area { get; set; }
        [InverseProperty(nameof(CameraConfiguration.Camera))]
        public virtual ICollection<CameraConfiguration> CameraConfigurations { get; set; }
        [InverseProperty(nameof(ViolationCase.Camera))]
        public virtual ICollection<ViolationCase> ViolationCases { get; set; }
    }
}
