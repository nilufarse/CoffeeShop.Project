using CoffeeShop.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Repository.Interfaces
{
    public interface IContactRepository : IGenericRepository<Product>
    {
        public Task<List<Product>> GetByCategoryIdAsync(int id);
    }
}
