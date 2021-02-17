using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.Account
{
    public class AccountPasswordParam
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
