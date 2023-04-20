using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.UI.Controllers
{
    public class OurMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
