using EVoucher.Cms.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher.Cms.Service.Manager
{
    public interface IValidationManager
    {
        void ValidCreateVoucherRequest(EvoucherRequest evoucherRequest);

        void ValidEditVoucherRequest(EvoucherRequest evoucherRequest);

        void ValidUpdateStatusRequest(long eVoucherId, bool isActive);
    }
}
