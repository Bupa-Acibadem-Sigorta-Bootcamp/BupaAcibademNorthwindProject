using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccessLayer.Abstract.UnitOfWorkRepository
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        bool BeginTransaction();
        bool RollBackTransaction();
        int SaveChanges();
    }
}
