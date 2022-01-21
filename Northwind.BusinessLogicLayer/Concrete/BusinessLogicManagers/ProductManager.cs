using System;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class ProductManager : BusinessLogicBase<Product, DtoProduct>, IProductService
    {
        public ProductManager(IServiceProvider service) : base(service)
        {
        }
    }
}