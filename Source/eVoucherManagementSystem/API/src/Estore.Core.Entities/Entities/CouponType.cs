using Estore.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Estore.Core.Entities.Entities
{
    [Table("coupon_type")]
    public class CouponType : Entity
    {
        [Column("type")]
        public string Type { get; set; }
    }
}
