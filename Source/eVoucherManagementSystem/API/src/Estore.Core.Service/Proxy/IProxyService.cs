using Estore.Core.Entities.Dtos;
using Estore.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Service.Proxy
{
    public interface IProxyService
    {
        Task<PromoCodeVerifyResponse> VerifyPromoCodeAsync(string promoCode);

        Task<IEnumerable<PromoCode>> GetUnusedEVoucherAsync();

        Task<IEnumerable<PromoCode>> GetUsedEVoucherAsync();
    }
}
