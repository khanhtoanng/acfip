using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("account")]
    public partial class Account
    {
        [Key]
        [Column("id")]
        [StringLength(50)]
        public string Id { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; }
        [Column("roleId")]
        public int? RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Account")]
        public virtual Role Role { get; set; }
    }
}
