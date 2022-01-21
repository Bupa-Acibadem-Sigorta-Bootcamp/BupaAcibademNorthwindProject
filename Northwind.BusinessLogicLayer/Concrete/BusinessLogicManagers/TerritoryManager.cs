using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.BusinessLogicLayer.Concrete.BusinessLogicLayerBase;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.ModelService;

namespace Northwind.BusinessLogicLayer.Concrete.BusinessLogicManagers
{
   public class TerritoryManager : BusinessLogicBase<Territory, DtoTerritory>, ITerritoryService
    {
        public TerritoryManager(IServiceProvider service) : base(service)
        {
        }
    }
}
