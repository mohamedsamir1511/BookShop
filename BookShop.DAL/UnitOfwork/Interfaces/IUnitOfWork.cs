using BookShop.DAL.Interfaces;
using BookShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.UnitOfwork.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public Task<int> CompleteAsync();//SAVE changes and int of number affected rows


    }
}
