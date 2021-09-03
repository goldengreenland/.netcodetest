using Estore.Core.Entities.Dtos;
using Estore.Core.Entities.Entities;
using Estore.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estore.Core.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EStoreController : ControllerBase
    {
        #region Private Variable
        private readonly IVoucherService _voucherService;
        #endregion Private Variable

        #region Constructor
        public EStoreController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        #endregion Constructor

        #region Public Method
        [HttpGet("GetAllEVoucher")]
        public async Task<IEnumerable<VoucherList>> GetAllEVoucher()
        {
            return await _voucherService.GetAllAsync();
        }

        [HttpPost("GetEVoucherDetailById")]
        public async Task<VoucherList> GetEVoucherDetailById(long eVoucherId)
        {
            return await _voucherService.GetEVoucherDetailByIdAsync(eVoucherId);
        }

        [HttpPost("VerifyPromoCode")]
        public async Task<PromoCodeVerifyResponse> VerifyPromoCode(string promoCode)
        {
            return await _voucherService.VerifyPromoCodeAsync(promoCode);
        }
        #endregion
    }
}
