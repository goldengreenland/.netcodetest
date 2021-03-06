using EVoucher.Cms.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EVoucher.Cms.Repository.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(long id);
    }
}
