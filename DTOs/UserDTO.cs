using System.ComponentModel.DataAnnotations;
using ShopManagement.Generics;

namespace ShopManagement.DTOs
{
    public class UserDTO : EntityBaseDTO
    {
        [Required] [MaxLength(255)] public string UserName { get; set; }

        public int RoleId { get; set; }
    }
}