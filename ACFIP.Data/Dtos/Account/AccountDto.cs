using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ACFIP.Data.Dtos.Role;

namespace ACFIP.Data.Dtos.Accounts
{
    public class AccountDto
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public virtual RoleDto Role { get; set; }
    }
}
