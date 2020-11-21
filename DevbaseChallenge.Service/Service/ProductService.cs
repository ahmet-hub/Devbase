using DevbaseChallenge.Core.DataAccess;
using DevbaseChallenge.Core.Entities;
using DevbaseChallenge.Core.Service;
using DevbaseChallenge.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevbaseChallenge.Service.Service
{
    public class ProductService:ServiceBase<Product>,IProductService
    {
        private readonly IEntityRepository<Product> _repositoy;
        public readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork, IEntityRepository<Product> repositoy) :base(unitOfWork,repositoy)
        {
            _repositoy = repositoy;
            _unitOfWork = unitOfWork;
          
        }
    }
}
