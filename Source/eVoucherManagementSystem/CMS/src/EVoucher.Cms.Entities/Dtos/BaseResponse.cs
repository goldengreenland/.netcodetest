using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher.Cms.Entities.Dtos
{
    public class BaseResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
