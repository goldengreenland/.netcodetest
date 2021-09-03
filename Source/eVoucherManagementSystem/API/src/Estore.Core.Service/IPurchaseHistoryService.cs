using Estore.Core.Entities.Dtos;
using Estore.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Service
{
    public interface IPurchaseHistoryService
    {
        
        Task<IEnumerable<PromoCode>> GetUnusedEVoucherAsync();

        Task<IEnumerable<PromoCode>> GetUsedEVoucherAsync();
    }
}
