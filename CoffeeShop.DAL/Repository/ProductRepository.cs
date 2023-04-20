using CoffeeShop.DAL.Data;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Repository
{
    public class ProductRepository : GenericRepository<Product>, IContactRepository
    {

        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Product>> GetByCategoryIdAsync(int id)
        {
            IQueryable<Product> products = _dbContext.Products.Where(p => p.ProductCategoryId == id);
            return products.ToList();
        }
    }
}
