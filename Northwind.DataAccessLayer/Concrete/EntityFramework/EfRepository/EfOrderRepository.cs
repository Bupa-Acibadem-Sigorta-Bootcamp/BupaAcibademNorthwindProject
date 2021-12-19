using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.DataAccessLayer.Abstract.GenericRepository;
using Northwind.DataAccessLayer.Abstract.IRepository;
using Northwind.DataAccessLayer.Concrete.EntityFramework.GenericRepository;
using Northwind.EntityLayer.Concrete.Models;

namespace Northwind.DataAccessLayer.Concrete.EntityFramework.EfRepository
{
    public class EfOrderRepository : EfGenericRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(DbContext context) : base(context)
        {
        }

        public IQueryable CustomerReport(int orderId)
        {
            return set.AsQueryable();
        }
    }
}
