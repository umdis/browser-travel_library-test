using BrowserTravel.Library.Entities.Models;
using BrowserTravel.Library.Infraestructure.Data;
using BrowserTravel.Library.Repository.Interfaces;

namespace BrowserTravel.Library.Repository.Repositories
{
    public class EditorialRepository : Repository<Editorial>, IEdirorialRepository
    {
        public EditorialRepository(ApplicationDbContext context) : base(context) { }

    }
}
