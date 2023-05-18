using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrowserTravel.Library.Entities.Models
{
    [Table("Roles")]
    public class Rol : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public bool State { get; set; } = true;

        public ICollection<User> Users { get; set; }
    }
}
