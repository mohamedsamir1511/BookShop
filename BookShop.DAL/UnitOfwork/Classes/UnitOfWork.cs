using BookShop.DAL.Context;
using BookShop.DAL.Interfaces;
using BookShop.DAL.UnitOfwork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BookShop.DAL.UnitOfwork.Classes
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public UnitOfWork(ApplicationDbContext db ,IProductRepository productRepository,ICategoryRepository categoryRepository)
        { 
            _db = db;
            Products = productRepository;
            Categories = categoryRepository;
        }
        public async Task<int> CompleteAsync()
        {
           return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
