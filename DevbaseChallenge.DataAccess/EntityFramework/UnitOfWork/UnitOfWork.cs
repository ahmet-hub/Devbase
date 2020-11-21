using DevbaseChallenge.Core.DataAccess;
using DevbaseChallenge.Core.UnitOfWork;
using DevbaseChallenge.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevbaseChallenge.DataAccess.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DevbaseChallengeContext _devbaseChallengeContext;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        public IProductRepository Product => _productRepository ??= new ProductRepository(_devbaseChallengeContext);
        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_devbaseChallengeContext);

        public UnitOfWork(DevbaseChallengeContext context)
        {
            _devbaseChallengeContext = context;
        }
        public void Commit()
        {
            _devbaseChallengeContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _devbaseChallengeContext.SaveChangesAsync();
        }
    }
}
