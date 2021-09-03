using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Core.Entities.Dtos
{
    public class PromoCodeResponse : BaseResponse
    {
        public string QRCodeUrl { get; set; }
        public string PromoCode { get; set; }
        public bool IsRedeemed { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
