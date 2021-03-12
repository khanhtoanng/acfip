using ACFIP.Data.Helpers;
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
        [ForeignKey(nameof(Location))]
        [Column("location_id", Order = 2)]
        public int? LocationId { get; set; }
        public Location Location { get; set; }
        [ForeignKey(nameof(CameraConfiguration))]
        [Column("configuration_id", Order = 3)]
        public int? ConfigId { get; set; }
        public CameraConfiguration Config { get; set; }
        [Column("connection_string", Order = 4)]
        public string ConnectionString { get; set; }
        [Required]
        [Column("is_active", Order = 5)]
        public bool IsActive { get; set; } = false;
        [Required]
        [Column("deleted_flag", Order = 6)]
        public bool DeletedFlag { get; set; } = false;
    }
}
