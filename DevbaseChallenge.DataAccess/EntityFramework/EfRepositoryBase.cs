using DevbaseChallenge.Core.DataAccess;
using DevbaseChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevbaseChallenge.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {

        public readonly DbContext _dbContext;
        public readonly DbSet<TEntity> _dbSet;

        public EfRepositoryBase(DevbaseChallengeContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }      

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;

        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbSet.ToListAsync();
            }
            var data= _dbSet.Where(predicate).ToList();
            return  data;
            
        }
       
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
