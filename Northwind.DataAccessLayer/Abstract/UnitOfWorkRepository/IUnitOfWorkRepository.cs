using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccessLayer.Abstract.GenericRepository;
using Northwind.EntityLayer.Concrete.Bases;

namespace Northwind.DataAccessLayer.Abstract.UnitOfWorkRepository
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : EntityBase;
        bool BeginTransaction();
        bool RollBackTransaction();
        int SaveChanges(); 
    }
}
