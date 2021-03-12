using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACFIP.Data.Models
{
    [Table("guard")]
    public class Guard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }

        [ForeignKey(nameof(Area))]
        [Column("area_id", Order = 1)]
        public int AreaId { get; set; }
        public Area Area { get; set; }
        [Column("fullname", Order = 2)]
        public string FullName { get; set; }
        [Column("time_start", Order = 3)]
        public TimeSpan TimeStart { get; set; }
        [Column("time_end", Order = 4)]
        public TimeSpan TimeEnd { get; set; }

    }
}
