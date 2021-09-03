using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Pcms.Core.Entities.Entities
{
    [Table("promocode")]
    public class PromoCode : IEntity
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("mobile")]
        public string Mobile { get; set; }

        [Column("qrcode_url")]
        public string QRCodeUrl { get; set; }

        [Column("promo_code")]
        public string Promo_Code { get; set; }

        [Column("IsRedeemed")]
        public bool IsRedeemed { get; set; }

        [Column("IsUsed")]
        public bool IsUsed { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }

        [Column("expiry_date")]
        public DateTime ExpiryDate { get; set; }
    }
}
