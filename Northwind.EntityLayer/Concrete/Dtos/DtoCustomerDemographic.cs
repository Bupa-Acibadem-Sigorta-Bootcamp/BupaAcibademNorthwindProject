using System.Collections.Generic;
using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Dtos   
{
    public partial class DtoCustomerDemographic : DtoBase
    {
        public DtoCustomerDemographic()
        {   
            
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }
    }
}