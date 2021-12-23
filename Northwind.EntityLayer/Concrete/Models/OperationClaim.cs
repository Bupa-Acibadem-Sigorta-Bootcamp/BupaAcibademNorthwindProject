using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Models
{
    public partial class OperationClaim : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
