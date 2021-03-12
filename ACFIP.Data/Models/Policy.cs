using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACFIP.Data.Models
{
    [Table("policy")]
    public class Policy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }

        [Column("number_of_violation", Order = 1)]
        public int NumberOfViolation { get; set; }
    }
}
