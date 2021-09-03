using Estore.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Estore.Core.Entities.Entities
{
    [Table("payment_method")]
    public class PaymentMethod : Entity
    {       
        [Column("name")]
        public string Name { get; set; }
    }
}
