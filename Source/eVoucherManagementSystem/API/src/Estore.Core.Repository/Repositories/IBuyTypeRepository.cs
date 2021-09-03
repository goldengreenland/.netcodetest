using Estore.Core.Entities.Entities;
using Estore.Core.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Repository.Repositories
{
    public interface IBuyTypeRepository : IRepository<BuyType>
    {
        Task<BuyType> GetByeVoucherId(long evoucherId);
    }
}
