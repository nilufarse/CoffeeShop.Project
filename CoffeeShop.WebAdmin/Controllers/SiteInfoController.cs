using CoffeeShop.BLL.Services.Inerfaces;
using CoffeeShop.DAL.Data;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.DAL.Dtos;
using CoffeeShop.WebAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.WebAdmin.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    public class SiteInfoController : Controller
    {
        private readonly IGenericService<SiteInfoDto, SiteInfo> _service;

        public SiteInfoController(IGenericService<SiteInfoDto, SiteInfo> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var siteinfos = await _service.GetListAsync();
            return View(siteinfos);
        }

        public async Task<IActionResult> Update(int id)
        {
            var siteinfo = await _service.GetByIdAsync(id);
            return View(siteinfo);

        }

        [HttpPost]
        public IActionResult Update(SiteInfoDto itemDto)
        {
            var siteinfo = _service.Update(itemDto);
            if (siteinfo != null)
            {
                TempData["success"] = "SiteInfo changed successfully.";
                return RedirectToAction("Index");
            }
            return View(siteinfo);

        }
    }
}