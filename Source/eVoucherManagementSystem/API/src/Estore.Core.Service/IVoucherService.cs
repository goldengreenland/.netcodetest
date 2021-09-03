using Estore.Core.Entities.Dtos;
using Estore.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Service
{
    public interface IVoucherService
    {
        Task<IEnumerable<VoucherList>> GetAllAsync();
        Task<VoucherList> GetEVoucherDetailByIdAsync(long eVoucherId);
        Task<PromoCodeVerifyResponse> VerifyPromoCodeAsync(string promoCode);
    }
}
