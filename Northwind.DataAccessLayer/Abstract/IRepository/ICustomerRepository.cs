using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.EntityLayer.Concrete.Models;

namespace Northwind.DataAccessLayer.Abstract.IRepository
{
    public interface ICustomerRepository
    {
        //TODO : bu sınıfa generic repositoryden kalıtım vermemiz gerekmez miydi? Hayır gerekmez burası nesnesin özel şablonunu tutar generic verirsek aynı şablonları tekrarlamış oluruz.
        Customer GetByStringId(string id);
    }
}
