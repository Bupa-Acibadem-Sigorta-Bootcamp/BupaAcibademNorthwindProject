using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccessLayer.Abstract.IRepository
{
    public interface IOrderRepository
    {
        //TODO : örnek olması için deneme amaçlı metod.
        //TODO : bu sınıfa generic repositoryden kalıtım vermemiz gerekmez miydi?
        IQueryable CustomerReport(int orderId);
    }
}