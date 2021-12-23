using System.Collections.Generic;
using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Dtos
{
    public partial class DtoRegion : DtoBase
    {
        public DtoRegion()
        {
           
        }

        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
    }
}