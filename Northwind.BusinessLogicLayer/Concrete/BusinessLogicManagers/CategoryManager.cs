using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.EntityLayer.Abstract.IBases;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class CategoryManager : BusinessLogicBase<Category, DtoCategory>, ICategoryService
    {
        public CategoryManager(IServiceProvider service) : base(service)
        {
        }
    }
}