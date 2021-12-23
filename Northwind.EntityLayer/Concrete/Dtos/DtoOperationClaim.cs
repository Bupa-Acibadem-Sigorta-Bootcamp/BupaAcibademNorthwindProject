using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Dtos
{
    public partial class DtoOperationClaim : DtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}