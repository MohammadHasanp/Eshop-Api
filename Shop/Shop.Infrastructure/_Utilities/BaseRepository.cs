using Common.Domain;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef._Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure._Utilities
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected  ShopContext _context;
        private  DbSet<TEntity> _dbSet;

        public BaseRepository(ShopContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRange(ICollection<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Any(expression);
        }

        public TEntity? Get(long id)
        {
            return _dbSet.FirstOrDefault(t=>t.Id.Equals(id));
        }

        public async Task<TEntity?> GetAsync(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(t=>t.Id.Equals(id));
        }

        public async Task<TEntity?> GetTracking(long id)
        {
            return await _dbSet.AsTracking().FirstOrDefaultAsync(t=>t.Id.Equals(id));
        }

        public async Task<int> Save()
        {
           return await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }
    }
}
