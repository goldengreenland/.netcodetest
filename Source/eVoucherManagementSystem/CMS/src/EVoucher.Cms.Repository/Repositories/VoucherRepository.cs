using EVoucher.Cms.Entities.Entities;
using EVoucher.Cms.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVoucher.Cms.Repository.Repositories
{
    public class VoucherRepository : Repository<Voucher, EVoucherDbContext>, IVoucherRepository
    {
        private readonly EVoucherDbContext _context;

        public VoucherRepository(EVoucherDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<long> GetLastInsertedID()
        {
            return _context.EVoucher.MaxAsync(p => p.Id);
        }
    }
}
