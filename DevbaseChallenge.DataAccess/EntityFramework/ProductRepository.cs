using DevbaseChallenge.Core.DataAccess;
using DevbaseChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevbaseChallenge.DataAccess.EntityFramework
{
    public class ProductRepository : EfRepositoryBase<Product>, IProductRepository
    {
        public DevbaseChallengeContext _devbaseChallengeContext { get => _dbContext as DevbaseChallengeContext; }

        public ProductRepository(DevbaseChallengeContext context) : base(context)
        {

        }
    }
}
