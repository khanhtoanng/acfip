using System;
using System.Collections.Generic;
using System.Text;
using ACFIP.Data.Dtos.Accounts;

namespace ACFIP.Data.Dtos.Role
{
   public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AccountDto> Accounts { get; set; }
    }
}
