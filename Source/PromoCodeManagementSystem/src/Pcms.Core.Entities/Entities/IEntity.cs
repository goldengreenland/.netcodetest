using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pcms.Core.Entities.Entities
{
    public interface IEntity
    {
        long Id { get; set; }
    }
}
