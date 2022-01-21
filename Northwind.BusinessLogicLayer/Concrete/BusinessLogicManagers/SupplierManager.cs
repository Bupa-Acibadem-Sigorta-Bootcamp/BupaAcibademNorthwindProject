using System;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class SupplierManager : BusinessLogicBase<Supplier, DtoSupplier>, ISupplierService
    {
        public SupplierManager(IServiceProvider service) : base(service)
        {
        }
    }
}