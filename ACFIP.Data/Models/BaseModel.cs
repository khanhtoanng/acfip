using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACFIP.Data.Models
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
