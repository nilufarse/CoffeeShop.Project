using CoffeeShop.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.UI.ViewModel
{
    public class OrderViewModel
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
