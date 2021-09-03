using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Core.Entities.Const
{
    public class ApiConstant
    {
    }

    public static class ApiModule
    {
        public const string PromoCode = "PromoCode";
    }

    public static class ApiMethod
    {
        public const string Verify = "Verify";
        public const string GetUnusedEVoucher = "GetUnusedEVoucher";
        public const string GetUsedEVoucher = "GetUsedEVoucher";
    }
}
