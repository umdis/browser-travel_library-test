using BrowserTravel.Library.Entities.Models;
using BrowserTravel.Library.Infraestructure.Data;
using BrowserTravel.Library.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Repository.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
