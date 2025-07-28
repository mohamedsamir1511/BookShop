using BookShop.DAL.Context;
using BookShop.DAL.Interfaces;
using BookShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Repositories
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext db):base(db)
        {
                
        }
    }
}
