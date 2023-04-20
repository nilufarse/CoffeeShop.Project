using CoffeeShop.DAL.DBModel;
using CoffeeShop.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BLL.Services.Inerfaces
{
    public interface IProductService : IGenericService<ProductDto, Product>
    {
        public Task<List<ProductCategoryDto>> GetCategoriesAsync();
        public Task<List<ProductDto>> GetProductsByCategoryIdAsync(int id);
        public Task<ProductDto> GetProductDetailByIdAsync(int id);
    }
}
