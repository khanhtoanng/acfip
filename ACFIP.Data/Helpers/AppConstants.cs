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
        public struct ViolationStatus
        {
            public const int DETECTED = 1;
            public const int NON_DETECTED = 0;
        }
        public struct ViolationType
        {
            public const int VEST = 1;
            public const int HELMET = 2;

        }
        public struct AreaViolated
        {
            public const int LOWER_POLICY = 0;
            public const int EQUAL_TO_POLICY = 1;
            public const int EXCEED_POLICY = 2;

        }
    }
}
