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
            public struct Monitor {
                public const string NAME = "Monitor";
                public const int ID = 2;
            }
            public struct Manager
            {
                public const string NAME = "Manager";
                public const int ID = 1;
            }
        }
    }
}
