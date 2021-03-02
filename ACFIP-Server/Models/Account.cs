using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACFIP_Server.Models
{
    [Table("account")]
    public class Account : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id", Order = 0)]
        public int Id { get; set; }
        [Required]
        [Column("hashed_password", Order = 1)]
        public string HashedPassword { get; set; }
        [Required]
        [Column("salt", Order = 2, TypeName = "binary(16)")]
        public byte[] Salt { get; set; }
        [Required]
        [ForeignKey(nameof(Role))]
        [Column("role_id", Order = 3)]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [Required]
        [Column("is_active", Order = 4)]
        public bool IsActive { get; set; } = true;
        [Required]
        [Column("deleted_flag", Order = 5)]
        public bool DeletedFlag { get; set; } = false;
    }
}
