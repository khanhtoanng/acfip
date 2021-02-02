﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP.Data.Models
{
    [Table("role")]
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
