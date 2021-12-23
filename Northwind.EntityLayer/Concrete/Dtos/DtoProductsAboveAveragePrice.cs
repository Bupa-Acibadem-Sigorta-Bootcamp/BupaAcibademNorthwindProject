using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Dtos
{
    public partial class DtoProductsAboveAveragePrice : DtoBase
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}