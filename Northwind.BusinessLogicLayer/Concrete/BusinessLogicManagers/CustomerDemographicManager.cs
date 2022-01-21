using System;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.EntityLayer.Concrete.Bases;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class CustomerDemographicManager : BusinessLogicBase<CustomerDemographic, DtoCustomerDemographic>, ICustomerDemographicService
    {
        public CustomerDemographicManager(IServiceProvider service) : base(service)
        {
        }
    }
}