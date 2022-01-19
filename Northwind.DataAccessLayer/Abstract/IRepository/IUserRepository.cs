using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.EntityLayer.Concrete.Models;

namespace Northwind.DataAccessLayer.Abstract.IRepository
{
    public interface IUserRepository
    {
        User Login(User userlogin);
    }
}