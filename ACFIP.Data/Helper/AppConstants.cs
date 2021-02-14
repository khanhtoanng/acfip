using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Helper
{
    public class AppConstants
    {
        public struct Camera
        {
            public const int ACTIVE = 1;
            public const int IN_ACTIVE = 0;
        }
        public struct Account
        {
            public const int ACTIVE = 1;
            public const int IN_ACTIVE = 0;
        }
        public struct SettingCameraOptions
        {
            public const int REFERENCE = 1;
            public const int UN_REFERENCE = 0;
        }
        public struct Role
        {
            public struct Monitor {
                public const string NAME = "Monitor";
                public const int ID = 1;
            }
            public struct Manager
            {
                public const string NAME = "Manager";
                public const int ID = 2;
            }
        }
    }
}
