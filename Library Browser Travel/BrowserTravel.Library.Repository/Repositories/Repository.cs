using BrowserTravel.Library.Entities.Models;
using BrowserTravel.Library.Infraestructure.Data;
using BrowserTravel.Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace BrowserTravel.Library.Repository.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(ApplicationDbContext));
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);

            var first = await query.Where(predicate).FirstOrDefaultAsync<T>();

            return first;
        }


        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<IList<T>> GetItems(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            List<T> list;

            var query = _context.Set<T>().AsQueryable();

            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);

            list = await query.Where(predicate).ToListAsync<T>();

            return list;
        }

        public async Task<IList<T>> GetItems(Expression<Func<T, bool>> predicate)
        {
            List<T> list = await _context.Set<T>().AsQueryable()
                .Where(predicate).ToListAsync();

            return list;
        }

        public async Task<bool> Remove(int id)
        {
            var entity = await Get(id);
            _context.Set<T>().Remove(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Update(int id, T entity)
        {
            _context.Set<T>().Update(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
