using System;
using System.Collections.Generic;
using System.Text;

namespace Pcms.Core.Entities.Dtos
{
    public class BaseResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
