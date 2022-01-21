using System;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
    public class EmployeeManager : BusinessLogicBase<Employee, DtoEmployee>, IEmployeeService
    {
        public EmployeeManager(IServiceProvider service) : base(service)
        {
        }
    }
}