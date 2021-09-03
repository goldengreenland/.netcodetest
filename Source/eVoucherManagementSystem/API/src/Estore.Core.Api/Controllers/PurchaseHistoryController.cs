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
    public class PurchaseHistoryController : ControllerBase
    {
        #region Private Variable
        private readonly IPurchaseHistoryService _purchaseHistoryService;
        #endregion Private Variable

        #region Constructor
        public PurchaseHistoryController(IPurchaseHistoryService purchaseHistoryService)
        {
            _purchaseHistoryService = purchaseHistoryService;
        }
        #endregion Constructor

        #region Public Method        
        [HttpGet("GetUnusedEVoucher")]
        public async Task<IEnumerable<PromoCode>> GetUnusedEVoucher()
        {
            return await _purchaseHistoryService.GetUnusedEVoucherAsync();
        }

        [HttpGet("GetUsedEVoucher")]
        public async Task<IEnumerable<PromoCode>> GetUsedEVoucher()
        {
            return await _purchaseHistoryService.GetUsedEVoucherAsync();
        }
        #endregion
    }
}
