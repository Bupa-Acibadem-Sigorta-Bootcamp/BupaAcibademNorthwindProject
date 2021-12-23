using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Dtos
{
    public partial class DtoCustomerCustomerDemo : DtoBase
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }
    }
}