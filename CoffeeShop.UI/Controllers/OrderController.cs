using CoffeeShop.DAL.Data;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.UI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.UI.Controllers
{
    
    public class OrderController : Controller
    {
        private readonly AppDbContext db;
        public OrderController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Order(int id)
        {
            var vm = new OrderViewModel();
            vm.Product = db.Products.Find(id);
            return View(vm);
        }

        public IActionResult OrderDetail(int id)
        {
            var vm = new OrderViewModel();
            vm.Order = db.Orders.Find(id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Order(OrderViewModel vm, Order order)
        {

            order = vm.Order;
            order.OrderDate = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();


            string DomainName = HttpContext.Request.Host.Value;



            var url = $"https://api.whatsapp.com/send?phone=+994507081929&text={DomainName}/order/orderdetail/{order.Id}";
            return Redirect(url);

        }
    }
}
