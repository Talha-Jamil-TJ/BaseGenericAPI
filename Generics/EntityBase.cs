using System;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Generics
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        [Required] public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}