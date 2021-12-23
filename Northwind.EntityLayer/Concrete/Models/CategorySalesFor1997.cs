using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Models
{
    public partial class CategorySalesFor1997 : EntityBase
    {
        public string CategoryName { get; set; }
        public decimal? CategorySales { get; set; }
    }
}
