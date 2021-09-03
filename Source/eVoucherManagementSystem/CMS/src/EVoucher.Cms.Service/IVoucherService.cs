using EVoucher.Cms.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVoucher.Cms.Service
{
    public interface IVoucherService
    {
        Task<EvoucherResponse> CreateAsync(EvoucherRequest evoucherRequest);
        Task<EvoucherResponse> EditAsync(EvoucherRequest evoucherRequest);
        Task<EvoucherResponse> UpdateStatusAsync(long eVoucherId, bool isActive);
    }
}
