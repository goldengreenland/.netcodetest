using Estore.Core.Entities.Dtos;
using Estore.Core.Entities.Entities;
using Estore.Core.Service.Proxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Service
{
    public class PurchaseHistoryService : IPurchaseHistoryService
    {
        #region Private Variable
        private readonly IProxyService _proxyService;
        #endregion

        #region Constructor
        public PurchaseHistoryService(IProxyService proxyService)
        {
            _proxyService = proxyService;
        }
        #endregion

        #region Public Method
        public Task<IEnumerable<PromoCode>> GetUnusedEVoucherAsync()
        {
            return _proxyService.GetUnusedEVoucherAsync();
        }

        public Task<IEnumerable<PromoCode>> GetUsedEVoucherAsync()
        {
            return _proxyService.GetUsedEVoucherAsync();
        }
        #endregion
    }
}
