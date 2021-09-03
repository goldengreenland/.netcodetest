using EVoucher.Cms.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EVoucher.Cms.Entities.Entities
{
    [Table("coupon_type")]
    public class CouponType : Entity
    {
        [Column("type")]
        public string Type { get; set; }
    }
}
