using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EntityLayer.Concrete.Dtos.DtoTokenOperations
{
    public class DtoUserToken
    {
        public DtoLoginUser DtoLoginUser { get; set; }
        public object AccessToken { get; set; }
    }
}
