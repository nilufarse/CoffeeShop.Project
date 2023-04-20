using CoffeeShop.BLL.Services.Inerfaces;
using CoffeeShop.DAL.Data;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.DAL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.WebAdmin.Controllers
{
    //[Authorize(Roles = "SuperAdmin,Operator")]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly AppDbContext db;

        public ProductsController(IProductService service, IHostingEnvironment hostingEnvironment, AppDbContext db)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            //var products = await _service.GetListAsync();
            return View(await db.Products.Include(x=>x.ProductCategory).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            ProductDto model = new ProductDto();
            model.CategoryDtos = await _service.GetCategoriesAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto itemDto, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string folderPath = @"Documents\ProductImages";
                string fullPath = Path.Combine(wwwRootPath, folderPath);
                itemDto.ProductDocuments = new List<ProductDocumentDto>();
                foreach (var file in files)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(file.FileName);
                    string realPath = Path.Combine(fullPath, fileName + extension);

                    using (var fileStream = new FileStream(realPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    ProductDocumentDto productDocument = new ProductDocumentDto()
                    {
                        DocumentUrl = @"Documents/ProductImages/" + fileName + extension,


                    };
                    itemDto.ProductDocuments.Add(productDocument);

                }
                if (itemDto.ProductDocuments.Count > 0)
                {
                    itemDto.ProfileDocPath = itemDto.ProductDocuments[0].DocumentUrl;
                }
                await _service.AddAsync(itemDto);

                TempData["success"] = "Product added succecfully";
                return RedirectToAction("Index");
            }


            return View(itemDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _service.GetByIdAsync(id.Value);
            if (products == null)
            {
                return NotFound();
            }

            ProductDto model = new()
            {
                Id = products.Id,
                Name = products.Name,
                Description = products.Description,
                UnitOfPrice = products.UnitOfPrice,
                TotalCount = products.TotalCount,
                ProductCategoryId = products.ProductCategoryId,
                CategoryDtos = await _service.GetCategoriesAsync(),
                ProductDocuments = products.ProductDocuments,
                ProfileDocPath = products.ProfileDocPath
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Update(int id, ProductDto itemDto, List<IFormFile> files)
        {
            if (id != itemDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string folderPath = @"Documents\ProductImages";
                string fullPath = Path.Combine(wwwRootPath, folderPath);

                itemDto.ProductDocuments = itemDto.ProductDocuments ?? new List<ProductDocumentDto>();

                foreach (var file in files)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(file.FileName);
                    string realPath = Path.Combine(fullPath, fileName + extension);

                    using (var fileStream = new FileStream(realPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    ProductDocumentDto productDocument = new ProductDocumentDto()
                    {
                        DocumentUrl = @"Documents/ProductImages/" + fileName + extension,
                    };

                    itemDto.ProductDocuments.Add(productDocument);
                }

                if (itemDto.ProductDocuments.Count > 0)
                {
                    itemDto.ProfileDocPath = itemDto.ProductDocuments[0].DocumentUrl;
                }

                _service.Update(itemDto);

                TempData["success"] = "Product changed successfully.";
                return RedirectToAction("Index");
            }

            return View(itemDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var products = await _service.GetByIdAsync(id);
            ViewBag.Category = new SelectList(await _service.GetCategoriesAsync(), "Id", "Name");
            return View(products);

        }
        [HttpPost]
        public IActionResult Delete(ProductDto itemDto)
        {
            _service.Delete(itemDto.Id);
            TempData["success"] = "Product successfully deleted.";
            return RedirectToAction("Index");


        }
    }
}

