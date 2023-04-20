using CoffeeShop.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext db;

        public AboutController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var siteInfo = db.SiteInfos.FirstOrDefault();
            return View(siteInfo);
        }
    }
}
