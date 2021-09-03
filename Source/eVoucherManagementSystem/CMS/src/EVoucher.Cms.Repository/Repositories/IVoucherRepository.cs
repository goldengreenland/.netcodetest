using EVoucher.Cms.Entities.Entities;
using EVoucher.Cms.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVoucher.Cms.Repository.Repositories
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<long> GetLastInsertedID();
    }
}
