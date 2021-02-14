using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ACFIP.Data.Dtos.Accounts;

namespace ACFIP.Data.Dtos.Role
{
   public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountDto> Accounts { get; set; }
    }
}
