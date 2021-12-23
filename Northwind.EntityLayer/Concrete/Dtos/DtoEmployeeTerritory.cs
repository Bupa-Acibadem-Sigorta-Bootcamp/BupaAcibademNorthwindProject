using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Dtos
{
    public partial class DtoEmployeeTerritory : DtoBase
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }
    }
}