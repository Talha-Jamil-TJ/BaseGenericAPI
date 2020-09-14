using System.ComponentModel.DataAnnotations;

namespace ShopManagement.DTOs
{
    public class UserForRegisterDTO
    {
        [Required] public string UserName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 15 characters")]
        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}