using EVoucher.Cms.Entities.Dtos;
using EVoucher.Cms.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVoucher.Cms.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EVoucherController : ControllerBase
    {
        #region Private Variable
        private readonly IVoucherService _voucherService;
        #endregion Private Variable

        #region Constructor
        public EVoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        #endregion Constructor

        #region Public Method
        [HttpPost("Create")]
        public async Task<EvoucherResponse> Create(EvoucherRequest evoucherRequest)
        {
            return (EvoucherResponse)await _voucherService.CreateAsync(evoucherRequest);
        }

        [HttpPost("Edit")]
        public async Task<EvoucherResponse> Edit(EvoucherRequest evoucherRequest)
        {
            return (EvoucherResponse)await _voucherService.EditAsync(evoucherRequest);
        }

        [HttpPost("UpdateStatus")]
        public async Task<EvoucherResponse> UpdateStatus(long eVoucherId, bool isActive)
        {
            return (EvoucherResponse)await _voucherService.UpdateStatusAsync(eVoucherId, isActive);
        }
        #endregion
    }
}
