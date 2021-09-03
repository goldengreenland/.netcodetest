using Pcms.Core.Entities.Dtos;
using Pcms.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pcms.Core.Service
{
    public interface IPromoCodeService
    {
        Task<GeneratePromoCodeResponse> GeneratePromoCodeAsync(GeneratePromoCodeRequest generatePromoCodeRequest);

        Task<PromoCodeVerifyResponse> VerifyPromoCodeAsync(string promoCode);

        Task<PromoCodeResponse> GetByPromoCodeAsync(string promoCode);

        Task<IEnumerable<PromoCode>> GetAllPromoCodeAsync();

        Task<IEnumerable<PromoCode>> GetUsedEVoucherAsync();
        Task<IEnumerable<PromoCode>> GetUnusedEVoucherAsync();
    }
}
