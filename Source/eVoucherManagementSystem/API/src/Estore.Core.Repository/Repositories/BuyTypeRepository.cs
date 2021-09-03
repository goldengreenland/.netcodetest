using Estore.Core.Entities.Entities;
using Estore.Core.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Repository.Repositories
{
    public class BuyTypeRepository : Repository<BuyType, EStoreDbContext>, IBuyTypeRepository
    {
        private readonly EStoreDbContext _context;

        public BuyTypeRepository(EStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BuyType> GetByeVoucherId(long evoucherId)
        {
            return await _context.Set<BuyType>().SingleOrDefaultAsync(p => p.EvoucherId == evoucherId);
        }
    }
}
