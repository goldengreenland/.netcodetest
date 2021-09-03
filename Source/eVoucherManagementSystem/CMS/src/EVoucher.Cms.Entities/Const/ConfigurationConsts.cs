using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher.Cms.Entities.Const
{
    public static class ConfigurationConsts
    {
        public static string DBConnectionString { get; set; }
        public static string MasterKey { get; set; }
        public static int SessionTimeOutMinutes { get; set; }
    }
}
