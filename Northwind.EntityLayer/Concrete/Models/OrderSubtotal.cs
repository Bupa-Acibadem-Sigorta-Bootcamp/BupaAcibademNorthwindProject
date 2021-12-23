using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Models
{
    public partial class OrderSubtotal : EntityBase
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
