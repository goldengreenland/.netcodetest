using EVoucher.Cms.Entities.Entities;
using EVoucher.Cms.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVoucher.Cms.Repository.Repositories
{
    public class BuyTypeRepository : Repository<BuyType, EVoucherDbContext>, IBuyTypeRepository
    {
        private readonly EVoucherDbContext _context;

        public BuyTypeRepository(EVoucherDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BuyType> GetByeVoucherId(long evoucherId)
        {
            return await _context.Set<BuyType>().SingleOrDefaultAsync(p => p.EvoucherId == evoucherId);
        }
    }
}
