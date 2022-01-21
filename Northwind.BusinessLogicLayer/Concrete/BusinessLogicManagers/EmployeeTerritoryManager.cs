using System;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class EmployeeTerritoryManager : BusinessLogicBase<EmployeeTerritory, DtoEmployeeTerritory>, IEmployeeTerritoryService
    {
        public EmployeeTerritoryManager(IServiceProvider service) : base(service)
        {
        }
    }
}