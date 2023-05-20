using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrowserTravel.Library.Entities.Models
{
    [Table("Users")]
    public class User: BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        public byte[] Salt { get; set; }

        [Required]
        public string SaltedAndHashedPassword { get; set; }

        [Required]
        public int IdRol { get; set; }

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public bool State { get; set; } = true;
    }
}
