using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity:BaseEntity
    {
        Task<TEntity> GetAsync(long id);
        Task<TEntity> GetTracking(long id);
        Task Add(TEntity entity);
        Task AddRange(ICollection<TEntity> entities);
        void Update(TEntity entity);
        Task<int> Save();
        Task<bool> ExistAsync(Expression<Func<TEntity,bool>> expression);
        bool Exists(Expression<Func<TEntity,bool>>expression);
        TEntity Get(long id);
    }
}
