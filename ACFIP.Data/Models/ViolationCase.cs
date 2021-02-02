﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("violation_case")]
    public partial class ViolationCase
    {
        public ViolationCase()
        {
            ViolationCaseType = new HashSet<ViolationCaseType>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("createTime", TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        [Column("image_url")]
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [Column("video_url")]
        [StringLength(255)]
        public string VideoUrl { get; set; }
        [Column("camera_id")]
        public int? CameraId { get; set; }

        [ForeignKey(nameof(CameraId))]
        [InverseProperty("ViolationCase")]
        public virtual Camera Camera { get; set; }
        [InverseProperty("ViolationCase")]
        public virtual ICollection<ViolationCaseType> ViolationCaseType { get; set; }
    }
}
