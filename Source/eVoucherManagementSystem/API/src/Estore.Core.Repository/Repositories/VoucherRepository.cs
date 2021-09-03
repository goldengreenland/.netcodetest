using Estore.Core.Entities.Entities;
using Estore.Core.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Estore.Core.Repository.Repositories
{
    public class VoucherRepository : Repository<VoucherList, EStoreDbContext>, IVoucherRepository
    {
        private readonly EStoreDbContext _context;

        public VoucherRepository(EStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VoucherList>> GetAllVouchers()
        {
            return await (from ev in _context.EVoucher.AsQueryable()
                          join bt in _context.BuyType on ev.Id equals bt.EvoucherId
                          join cp in _context.CouponType on bt.CouponTypeId equals cp.Id
                          join pm in _context.PaymentMethod on ev.PaymentMethodId equals pm.Id
                          join pms in _context.PaymentMethodDiscount on ev.PaymentMethodDiscountId equals pms.Id
                          where ev.Status == true
                          select new VoucherList
                          {
                            Voucher = ev,
                            BuyType = bt,
                            CouponType = cp,
                            PaymentMethod = pm,
                            PaymentMethodDiscount = pms
                          }).ToListAsync();

        }

        public async Task<VoucherList> GetEVoucherDetailById(long eVoucherId)
        {
            return await(from ev in _context.EVoucher.AsQueryable()
                         join bt in _context.BuyType on ev.Id equals bt.EvoucherId
                         join cp in _context.CouponType on bt.CouponTypeId equals cp.Id
                         join pm in _context.PaymentMethod on ev.PaymentMethodId equals pm.Id
                         join pms in _context.PaymentMethodDiscount on ev.PaymentMethodDiscountId equals pms.Id
                         where ev.Status == true && ev.Id == eVoucherId
                         select new VoucherList
                         {
                             Voucher = ev,
                             BuyType = bt,
                             CouponType = cp,
                             PaymentMethod = pm,
                             PaymentMethodDiscount = pms
                         }).FirstOrDefaultAsync();
        }
    }
}
