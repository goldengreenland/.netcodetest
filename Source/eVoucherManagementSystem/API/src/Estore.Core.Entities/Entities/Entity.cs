using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Estore.Core.Entities.Entities
{
    public class Entity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
