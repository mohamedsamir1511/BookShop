using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);//for Loading type
        Task<T>GetByIdAsync(int id);
        Task AddAsync(T item);
        void Update(T item);

        void Delete(T itme);
    }
}
