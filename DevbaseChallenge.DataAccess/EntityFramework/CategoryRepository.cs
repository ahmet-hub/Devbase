using DevbaseChallenge.Core.DataAccess;
using DevbaseChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevbaseChallenge.DataAccess.EntityFramework
{
    public class CategoryRepository : EfRepositoryBase<Category>, ICategoryRepository
    {
        public DevbaseChallengeContext _devbaseChallengeContext { get => _dbContext as DevbaseChallengeContext; }

        public CategoryRepository(DevbaseChallengeContext context) : base(context)
        {

        }
    }
}
