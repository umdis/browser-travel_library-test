using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Entities.Dto.Library
{
    public class AuthorDto
    {
        [Required]
        [StringLength(45, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(45, MinimumLength = 3)]
        public string LastName { get; set; }
    }
}
