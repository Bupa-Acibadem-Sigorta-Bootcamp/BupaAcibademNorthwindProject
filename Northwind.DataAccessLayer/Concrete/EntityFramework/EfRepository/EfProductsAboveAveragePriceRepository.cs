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
    public class EfProductsAboveAveragePriceRepository : EfGenericRepository<ProductsAboveAveragePrice>, IProductsAboveAveragePriceRepository
    {
        public EfProductsAboveAveragePriceRepository(DbContext context) : base(context)
        {
        }
    }
}
