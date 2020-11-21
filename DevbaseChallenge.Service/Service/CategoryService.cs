using DevbaseChallenge.Core.DataAccess;
using DevbaseChallenge.Core.Entities;
using DevbaseChallenge.Core.Service;
using DevbaseChallenge.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevbaseChallenge.Service.Service
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly IEntityRepository<Category> _repositoy;
        public readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork, IEntityRepository<Category> repositoy) : base(unitOfWork, repositoy)
        {
            _repositoy = repositoy;
            _unitOfWork = unitOfWork;

        }
    }
}
