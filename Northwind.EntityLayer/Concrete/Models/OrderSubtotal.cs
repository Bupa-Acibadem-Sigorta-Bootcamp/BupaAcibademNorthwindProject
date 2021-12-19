#nullable disable

namespace Northwind.EntityLayer.Concrete.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
