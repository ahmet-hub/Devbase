using DevbaseChallenge.Core.DataAccess;
using DevbaseChallenge.Core.Entities;
using DevbaseChallenge.Core.Service;
using DevbaseChallenge.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevbaseChallenge.Service.Service
{
    public class ServiceBase<TEntity> : IService<TEntity> where TEntity : class, IEntity, new()

    {
       
        private IUnitOfWork _unitOfWork;
        private IEntityRepository<TEntity> _repository;

        

        public ServiceBase(IUnitOfWork unitOfWork, IEntityRepository<TEntity> repositoy)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repositoy;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
           

            if (predicate == null)
            {
               return await _repository.GetAllAsync();
            }
            else
            {
               return await _repository.GetAllAsync(predicate);
            }
            
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public TEntity Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
            return entity;
        }
    }

}
