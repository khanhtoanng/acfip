using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Account
{
    public class AccountCreateParam
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }


    }
}
