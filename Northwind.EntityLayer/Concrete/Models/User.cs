using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Models
{
    public partial class User : EntityBase
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
