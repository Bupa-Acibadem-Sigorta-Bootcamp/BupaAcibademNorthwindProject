using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccessLayer.Abstract.UnitOfWorkRepository;

namespace Northwind.DataAccessLayer.Concrete.EntityFramework.UnitOfWorkRepository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public bool RollBackTransaction()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
