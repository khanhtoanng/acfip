using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Helpers
{
    public class AppConstants
    {
        public struct SettingCameraOptions
        {
            public const int REFERENCE = 1;
            public const int UN_REFERENCE = 0;
        }
        public struct Role
        {
            public struct Admin 
            {
                public const string NAME = "Admin";
                public const int ID = 1;
            }
            public struct Monitor 
            {
                public const string NAME = "Monitor";
                public const int ID = 3;
            }
            public struct Manager
            {
                public const string NAME = "Manager";
                public const int ID = 2;
            }
        }
    }
}
