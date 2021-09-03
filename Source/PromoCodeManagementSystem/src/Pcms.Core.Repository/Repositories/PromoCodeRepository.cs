using Microsoft.EntityFrameworkCore;
using Pcms.Core.Entities.Entities;
using Pcms.Core.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcms.Core.Repository.Repositories
{
    public class PromoCodeRepository : Repository<PromoCode, PcmsDbContext>, IPromoCodeRepository
    {
        private readonly PcmsDbContext _context;

        public PromoCodeRepository(PcmsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PromoCode> GetByPromoCode(string promoCode)
        {
            return await _context.Set<PromoCode>().SingleOrDefaultAsync(p => p.Promo_Code == promoCode);
        }

        public async Task<IEnumerable<PromoCode>> GetUnusedEVoucher()
        {
            return await _context.Set<PromoCode>().Where(p => p.IsRedeemed == false).ToListAsync();
        }

        public async Task<IEnumerable<PromoCode>> GetUsedEVoucher()
        {
            return await _context.Set<PromoCode>().Where(p => p.IsRedeemed == true).ToListAsync();
        }
    }
}
