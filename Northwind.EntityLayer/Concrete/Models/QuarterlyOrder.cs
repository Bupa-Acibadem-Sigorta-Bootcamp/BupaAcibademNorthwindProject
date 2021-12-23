using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Models
{
    public partial class QuarterlyOrder : EntityBase
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
