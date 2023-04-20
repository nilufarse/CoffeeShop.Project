using CoffeeShop.DAL.Data;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.UI.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        readonly AppDbContext db;
        public ProductViewComponent(AppDbContext db)
        {
            this.db = db;
        }
        public Task<IViewComponentResult> InvokeAsync(int? category, int id, bool main)
        {
            var vm = new DataViewModel();
            var product = db.Products.Include(p=>p.ProductCategory).Where(p => p.DeletedDate == null).ToList();
            vm.Products = product;
            vm.Products = (List<Product>)null;

            if (category == null)
            {
                vm.Products = db.Products.Include(p => p.ProductCategory).Where(p => p.DeletedDate == null).ToList();
            }
            else
            {
                vm.Products = db.Products.Include(p => p.ProductCategory).Where(p => p.DeletedDate == null && p.ProductCategoryId == category).ToList();
            }
            if(id > 0)
            {
                vm.Products = db.Products.Include(p => p.ProductCategory).Where(p => p.Id == id).ToList();
            }
            if (main)
            {
                vm.Products = db.Products.Include(p => p.ProductCategory).Take(3);

            }

     
            return Task.FromResult<IViewComponentResult>(View(vm));
        }
    }
}
