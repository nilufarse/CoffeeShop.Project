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
    public class SocialController : Controller
    {
        private readonly IGenericService<SiteSocialLinkDto, SiteSocialLink> _service;

        public SocialController(IGenericService<SiteSocialLinkDto, SiteSocialLink> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var socials = await _service.GetListAsync();
            return View(socials);
        }

        public async Task<IActionResult> Update(int id)
        {
            var social = await _service.GetByIdAsync(id);
            return View(social);

        }

        [HttpPost]
        public IActionResult Update(SiteSocialLinkDto itemDto)
        {
            var social = _service.Update(itemDto);
            if (social != null)
            {
                TempData["success"] = "SocialLink changed successfully.";
                return RedirectToAction("Index");
            }
            return View(social);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var social = await _service.GetByIdAsync(id);

            return View(social);

        }
        [HttpPost]
        public IActionResult Delete(SiteSocialLinkDto itemDto)
        {
            _service.Delete(itemDto.Id);
            TempData["success"] = "SocialLink successfully deleted.";
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SiteSocialLinkDto itemDto)
        {

            var social = await _service.AddAsync(itemDto);
            if (social != null)
            {
                TempData["success"] = "SocialLink successfully added.";
                return RedirectToAction("Index");
            }
            return Ok(social);
        }
    }
}
