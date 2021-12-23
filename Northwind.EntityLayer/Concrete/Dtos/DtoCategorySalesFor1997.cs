using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Dtos   
{
    public partial class DtoCategorySalesFor1997 : DtoBase
    {
        public string CategoryName { get; set; }
        public decimal? CategorySales { get; set; }
    }
}