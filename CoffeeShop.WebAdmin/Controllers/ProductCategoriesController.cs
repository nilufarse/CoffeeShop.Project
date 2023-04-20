using CoffeeShop.BLL.Services.Inerfaces;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.DAL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.WebAdmin.Controllers
{
    //[Authorize(Roles = "SuperAdmin,Operator")]
    public class ProductCategoriesController : Controller
    {
        private readonly IGenericService<ProductCategoryDto, ProductCategory> _service;

        public ProductCategoriesController(IGenericService<ProductCategoryDto, ProductCategory> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetListAsync();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryDto itemDto)
        {

            var category = await _service.AddAsync(itemDto);
            if (category != null)
            {
                TempData["success"] = "Category successfully added.";
                return RedirectToAction("Index");
            }
            return Ok(category);
        }
        public async Task<IActionResult> Update(int id)
        {
            var category = await _service.GetByIdAsync(id);
            return View(category);

        }

        [HttpPost]
        public IActionResult Update(ProductCategoryDto itemDto)
        {
            var category = _service.Update(itemDto);
            if (category != null)
            {
                TempData["success"] = "Category changed successfully.";
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _service.GetByIdAsync(id);

            return View(category);

        }
        [HttpPost]
        public IActionResult Delete(ProductCategoryDto itemDto)
        {
            _service.Delete(itemDto.Id);
            TempData["success"] = "Category successfully deleted.";
            return RedirectToAction("Index");


        }

    }
}
