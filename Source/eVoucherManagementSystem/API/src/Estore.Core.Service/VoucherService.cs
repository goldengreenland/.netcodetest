using Estore.Core.Entities.Const;
using Estore.Core.Entities.Dtos;
using Estore.Core.Entities.Entities;
using Estore.Core.Repository.Repositories;
using Estore.Core.Service.Manager;
using Estore.Core.Service.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Service
{
    public class VoucherService : IVoucherService
    {
        #region Private variable
        private readonly IVoucherRepository _voucherRepository;
        private readonly IValidationManager _validationManager;
        private readonly IBuyTypeRepository _buyTypeRepository;
        private readonly IProxyService _proxyService;
        #endregion

        #region Constructor
        public VoucherService(IVoucherRepository voucherRepository,
                              IBuyTypeRepository buyTypeRepository,
                              IValidationManager validationManager,
                              IProxyService proxyService)
        {
            _voucherRepository = voucherRepository;
            _buyTypeRepository = buyTypeRepository;
            _validationManager = validationManager;
            _proxyService = proxyService;
        }
        #endregion

        #region Public Method

        public async Task<IEnumerable<VoucherList>> GetAllAsync()
        {
          return  await _voucherRepository.GetAllVouchers();
        }

        public async Task<VoucherList> GetEVoucherDetailByIdAsync(long eVoucherId)
        {
            return await _voucherRepository.GetEVoucherDetailById(eVoucherId);
        }

        public Task<PromoCodeVerifyResponse> VerifyPromoCodeAsync(string promoCode)
        {
            return _proxyService.VerifyPromoCodeAsync(promoCode);
        }
        #endregion

        #region Private Method

        #endregion
    }
}
