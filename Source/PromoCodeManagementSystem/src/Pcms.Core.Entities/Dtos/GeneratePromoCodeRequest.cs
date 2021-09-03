using System;
using System.Collections.Generic;
using System.Text;

namespace Pcms.Core.Entities.Dtos
{
    public class GeneratePromoCodeRequest
    {
        public string Mobile { get; set; }

        public long Quantity { get; set; }     
    }
}
