﻿using ACFIP.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("camera")]
    public class Camera : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [Required]
        [Column("name", Order = 1)]
        public string Name { get; set; }
        [Required]
        [Column("status", Order = 2)]
        public int Status { get; set; } =  AppConstants.Camera.ACTIVE;
        [Required]
        [Column("deleted_flag", Order = 4)]
        public bool DeletedFlag { get; set; } = false;
        [Required]
        [ForeignKey(nameof(Area))]
        [Column("area_id", Order = 3)]
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
