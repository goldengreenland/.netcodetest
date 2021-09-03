using EVoucher.Cms.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EVoucher.Cms.Entities.Entities
{
    [Table("payment_method_discount")]
    public class PaymentMethodDiscount : Entity
    {
        [Column("payment_method_id")]
        public long PaymentMethodId { get; set; }

        [Column("discount_rate")]
        public int DiscountRate { get; set; }
    }
}
