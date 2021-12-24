using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.EntityLayer.Concrete.Dtos;
using Northwind.EntityLayer.Concrete.Models;
using Northwind.InterfaceLayer.Abstract.GenericService.Abstract;

namespace Northwind.InterfaceLayer.Abstract.ModelService
{
    public interface ICategorySalesFor1997Service : IGenericService<CategorySalesFor1997, DtoCategorySalesFor1997>
    {
    }
}