using Estore.Core.Entities.Entities;
using System;

namespace Estore.Core.Entities.Dtos
{
    public class EvoucherRequest : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime ExpiryDate { get; set; }

        public byte[] Image { get; set; }

        public long PaymentMethodId { get; set; }

        public long PaymentMethodDiscountId { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }

        public long CouponTypeId { get; set; }

        public BuyType BuyType { get; set; }
        
        public bool Status { get; set; }
    }
}
