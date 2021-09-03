using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pcms.Core.Entities.Dtos;
using Pcms.Core.Entities.Entities;
using Pcms.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pcms.Core.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        #region Private Variable
        private readonly IPromoCodeService _promoCodeService;      
        #endregion Private Variable

        #region Constructor
        public PromoCodeController(IPromoCodeService promoCodeService)
        {
            _promoCodeService = promoCodeService;
        }
        #endregion Constructor

        #region Public Method
        [HttpPost("GeneratePromoCode")]
        public async Task<GeneratePromoCodeResponse> GeneratePromoCodeAsync(GeneratePromoCodeRequest generatePromoCodeRequest)
        {
            return (GeneratePromoCodeResponse)await _promoCodeService.GeneratePromoCodeAsync(generatePromoCodeRequest);
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<PromoCode>> GetAllPromoCode()
        {
            return (IEnumerable<PromoCode>)await _promoCodeService.GetAllPromoCodeAsync();
        }

        [HttpPost("Verify")]
        public async Task<PromoCodeVerifyResponse> VerifyPromoCode(string promoCode)
        {
            return (PromoCodeVerifyResponse) await _promoCodeService.VerifyPromoCodeAsync(promoCode);
        }

        [HttpPost("GetByPromoCode")]
        public async Task<PromoCodeResponse> GetByPromoCodeAsync(string promoCode)
        {
            return (PromoCodeResponse)await _promoCodeService.GetByPromoCodeAsync(promoCode);
        }

        [HttpGet("GetUnusedEVoucher")]
        public async Task<IEnumerable<PromoCode>> GetUnusedEVoucher()
        {
            return (IEnumerable<PromoCode>)await _promoCodeService.GetUnusedEVoucherAsync();
        }

        [HttpGet("GetUsedEVoucher")]
        public async Task<IEnumerable<PromoCode>> GetUsedEVoucher()
        {
            return (IEnumerable<PromoCode>)await _promoCodeService.GetUsedEVoucherAsync();
        }
        #endregion
    }
}
