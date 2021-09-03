using System;
using System.Collections.Generic;
using System.Text;

namespace Pcms.Core.Entities.Dtos
{
    public class PromoCodeRequest
    {
        public long Id { get; set; }
        public string PromoCode { get; set; }
        public string Mobile { get; set; }
    }
}
