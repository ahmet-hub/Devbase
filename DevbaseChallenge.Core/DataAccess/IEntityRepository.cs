using DevbaseChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevbaseChallenge.Core.DataAccess
{
    public interface IEntityRepository<TEntity>
        where TEntity:class, IEntity,new()
    {     
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate=null);      
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
