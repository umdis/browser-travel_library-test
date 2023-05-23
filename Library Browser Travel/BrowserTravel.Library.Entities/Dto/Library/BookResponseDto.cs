using BrowserTravel.Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BrowserTravel.Library.Entities.Dto.Library
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public Editorial Editorial { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int NumberPages { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
