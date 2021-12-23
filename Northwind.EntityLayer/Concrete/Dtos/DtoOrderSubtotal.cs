using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Dtos
{
    public partial class DtoOrderSubtotal : DtoBase
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}