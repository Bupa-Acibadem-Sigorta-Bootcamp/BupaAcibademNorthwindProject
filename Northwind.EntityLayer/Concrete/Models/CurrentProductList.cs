using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Models
{
    public partial class CurrentProductList : EntityBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
