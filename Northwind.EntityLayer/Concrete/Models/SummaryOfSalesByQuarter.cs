using System;
using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Models
{
    public partial class SummaryOfSalesByQuarter : EntityBase
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
