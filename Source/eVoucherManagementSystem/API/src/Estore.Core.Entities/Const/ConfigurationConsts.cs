using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Core.Entities.Const
{
    public static class ConfigurationConsts
    {
        public static string DBConnectionString { get; set; }
        public static string MasterKey { get; set; }
        public static int SessionTimeOutMinutes { get; set; }
        public static string PcmsApiUrl { get; set; }
        public static int TimeOut { get; set; }
    }
}
