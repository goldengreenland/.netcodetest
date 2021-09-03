using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Core.Entities.Entities
{
    public class PromoCode
    {
        public long Id { get; set; }
        public string Mobile { get; set; }
        public string QRCodeUrl { get; set; }

        public string Promo_Code { get; set; }
        public bool IsRedeemed { get; set; }
        public bool IsUsed { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
