using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLogicLayer.Concrete.Md5HashOperation
{
    public class Md5HashGenerator
    {
        public static string MD5Hash(string password)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
                var passwordResult = BitConverter.ToString(result);
                return passwordResult.Replace("-", "");
            }
        }
    }
}
