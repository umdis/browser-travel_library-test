using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrowserTravel.Library.Entities.Models
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        public string ISBN { get; set; }

        [Required]
        public int IdEditorial { get; set; }

        [ForeignKey("IdEditorial")]
        public Editorial Editorial { get; set; }

        [StringLength(45)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        public string Synopsis { get; set; }

        public int NumberPages { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
