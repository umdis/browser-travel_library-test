using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrowserTravel.Library.Entities.Models
{
    [Table("Authors")]
    public class Author : BaseEntity
    {
        [StringLength(45)]
        public string Name { get; set; }

        [StringLength(45)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
