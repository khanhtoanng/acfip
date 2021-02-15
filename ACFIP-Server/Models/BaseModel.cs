using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP_Server.Models
{
    public class BaseModel
    {
        [Required]
        [Column("created_time")]
        public DateTime CreatedTime { get; set; }
        [Required]
        [Column("last_modified_time")]
        public DateTime LastModifiedTime { get; set; }
    }
}
