using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Models
{
    public class BaseModel
    {
        [Required]
        [Column("created_time")]
        public DateTime CreatedTime { get; set; }
    }
}
