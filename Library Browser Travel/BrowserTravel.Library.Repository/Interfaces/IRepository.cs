using BrowserTravel.Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BrowserTravel.Library.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<bool> Remove(int id);
        Task<bool> Update(int id, T entity);
        Task<T> Get(int id);
        Task<T> Get(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        IQueryable<T> GetAll();
        Task<IList<T>> GetItems(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        Task<IList<T>> GetItems(Expression<Func<T, bool>> predicate);
    }
}