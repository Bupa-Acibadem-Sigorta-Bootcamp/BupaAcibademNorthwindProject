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
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        public EfUserRepository(DbContext context) : base(context)
        {
        }

        public User Login(User userlogin)
        {
            //var user = set.Where(x => x.Email == userlogin.Email && x.PasswordHash == userlogin.PasswordHash).SingleOrDefault();
            //var user = set.SingleOrDefault(x => x.Email == userlogin.Email && x.PasswordHash == userlogin.PasswordHash);

            var user = set.FirstOrDefault(x => x.Email == userlogin.Email && x.PasswordHash == userlogin.PasswordHash);
            return user;
        }
    }
}
