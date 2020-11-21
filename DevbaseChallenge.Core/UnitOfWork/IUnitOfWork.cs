using DevbaseChallenge.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevbaseChallenge.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }

        Task CommitAsync();
        void Commit();
    }
}
