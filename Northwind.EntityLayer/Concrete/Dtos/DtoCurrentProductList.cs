using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Dtos   
{
    public partial class DtoCurrentProductList : DtoBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}