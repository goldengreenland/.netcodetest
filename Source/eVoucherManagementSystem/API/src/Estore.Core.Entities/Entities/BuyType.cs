using Estore.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Estore.Core.Entities.Entities
{
    [Table("buy_type")]
    public class BuyType : Entity
    {

        [Column("evoucher_id")]
        public long EvoucherId { get; set; }

        [Column("coupon_type_id")]
        public long CouponTypeId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("max_limit_byself")]
        public int MaxLimitBySelf { get; set; }

        [Column("max_limit_bygift")]
        public int MaxLimitByGift { get; set; }
    }
}
