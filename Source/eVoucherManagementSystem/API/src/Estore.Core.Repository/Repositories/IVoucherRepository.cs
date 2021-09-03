using Estore.Core.Entities.Entities;
using Estore.Core.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Repository.Repositories
{
    public interface IVoucherRepository : IRepository<VoucherList>
    {
        Task<IEnumerable<VoucherList>> GetAllVouchers();

        Task<VoucherList> GetEVoucherDetailById(long eVoucherId);
    }
}
