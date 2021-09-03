using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EVoucher.Cms.Entities.Entities
{
    [Table("eVoucher")]
    public class Voucher : Entity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("expiry_date")]
        public DateTime ExpiryDate { get; set; }

        [Column("image")]
        public byte[] Image { get; set; }

        [Column("payment_method_id")]
        public long PaymentMethodId { get; set; }

        [Column("payment_method_discount_id")]
        public long PaymentMethodDiscountId { get; set; }
        
        [Column("amount")]
        public decimal Amount { get; set; }
        
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("created_date")]
        public DateTime Created_date { get; set; }

        [Column("updated_date")]
        public DateTime? Updated_date { get; set; }

        [Column("status")]
        public bool Status { get; set; }
    }
}
