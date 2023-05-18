using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrowserTravel.Library.Entities.Models
{
    [Table("Editorials")]
    public class Editorial : BaseEntity
    {
        [StringLength(45)]
        public string Name { get; set; }

        [StringLength(45)]
        public string Site { get; set; }
    }
}
