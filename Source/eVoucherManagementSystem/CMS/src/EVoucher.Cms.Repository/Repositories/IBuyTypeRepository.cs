using EVoucher.Cms.Entities.Entities;
using EVoucher.Cms.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVoucher.Cms.Repository.Repositories
{
    public interface IBuyTypeRepository : IRepository<BuyType>
    {
        Task<BuyType> GetByeVoucherId(long evoucherId);
    }
}
