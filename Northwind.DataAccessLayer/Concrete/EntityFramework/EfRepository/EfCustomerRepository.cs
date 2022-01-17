using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.DataAccessLayer.Abstract.IRepository;
using Northwind.DataAccessLayer.Concrete.EntityFramework.GenericRepository;
using Northwind.EntityLayer.Concrete.Models;

namespace Northwind.DataAccessLayer.Concrete.EntityFramework.EfRepository
{
    public class EfCustomerRepository : EfGenericRepository<Customer>, ICustomerRepository
    {
        public EfCustomerRepository(DbContext context) : base(context)
        {
        }

        public Customer GetByStringId(string id)
        {
            var customerStringId = set.SingleOrDefault(x => x.CustomerId == id);
            return customerStringId;
        }
    }
}
