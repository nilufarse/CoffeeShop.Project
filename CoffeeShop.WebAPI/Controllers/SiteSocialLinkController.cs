using CoffeeShop.BLL.Services.Inerfaces;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.DAL.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteSocialLinkController : ControllerBase
    {
        private readonly IGenericService<SiteSocialLinkDto, SiteSocialLink> _service;

        public SiteSocialLinkController(IGenericService<SiteSocialLinkDto, SiteSocialLink> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SiteSocialLinkDto>>> GetList()
        {
            var response = await _service.GetListAsync();
            return response;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SiteSocialLinkDto>> GetByIdAsync(int id)

        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _service.GetByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<SiteSocialLinkDto>> Create(SiteSocialLinkDto itemDto)
        {

            var response = await _service.AddAsync(itemDto);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<SiteSocialLinkDto> Update(int id, [FromBody] SiteSocialLinkDto obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }

            var response = _service.GetByIdAsync(id).Result;
            if (response == null)
            {
                return NotFound();
            }
            response = _service.Update(obj);
            return Ok(response); ;
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = _service.GetByIdAsync(id).Result;
            if (response == null)
            {
                return NotFound();
            }

            _service.Delete(id);
            return NoContent();
        }
    }
}
