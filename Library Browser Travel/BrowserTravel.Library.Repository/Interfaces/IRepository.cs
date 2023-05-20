using BrowserTravel.Library.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<bool> Remove(int id);
        Task<bool> Update(int id, T entity);
        Task<T> Get(int id);
        IQueryable<T> GetAll();
    }
}