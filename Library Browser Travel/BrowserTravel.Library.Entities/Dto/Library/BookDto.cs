using BrowserTravel.Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Entities.Dto.Library
{
    public class BookDto
    {
        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required]
        public int IdEditorial { get; set; }

        [StringLength(45)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        public string Synopsis { get; set; }

        public int NumberPages { get; set; }

        public virtual ICollection<int> Authors { get; set; }
    }
}
