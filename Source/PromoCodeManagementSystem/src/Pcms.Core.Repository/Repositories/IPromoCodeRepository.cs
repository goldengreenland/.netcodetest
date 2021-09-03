using Pcms.Core.Entities.Entities;
using Pcms.Core.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pcms.Core.Repository.Repositories
{
    public interface IPromoCodeRepository : IRepository<PromoCode>
    {
        Task<PromoCode> GetByPromoCode(string PromoCode);

        Task<IEnumerable<PromoCode>> GetUnusedEVoucher();

        Task<IEnumerable<PromoCode>> GetUsedEVoucher();
    }
}
