using BookShop.DAL.Context;
using BookShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>where T:class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet <T>_dbset;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
          _dbset=_db.Set<T>();
           
        }
        public async Task AddAsync(T item)
        {
             await _dbset.AddAsync(item);
        }

        public void Delete(T item)
        {
            _dbset.Remove(item);
            
        }

        public async Task<IEnumerable<T>> GetAllAsync(params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbset;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _dbset.FindAsync(id);
        }

        public void Update(T item)
        {
            _dbset.Update(item);
        }
    }
}
