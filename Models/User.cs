using System.ComponentModel.DataAnnotations;
using ShopManagement.Generics;

namespace ShopManagement.models
{
    public class User : EntityBase
    {
        [Required] [MaxLength(255)] public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}