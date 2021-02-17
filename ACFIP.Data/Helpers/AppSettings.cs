using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Helpers
{
    public class AppSettings
    {
        public string DbConnectionString { get; set; }
        public string JwtSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
