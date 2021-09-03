using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Core.Entities.Entities
{
    public class VoucherList
    {
        public Voucher Voucher { get; set; }
        public BuyType BuyType { get; set; }
        public CouponType CouponType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentMethodDiscount PaymentMethodDiscount { get; set; }
    }
}
