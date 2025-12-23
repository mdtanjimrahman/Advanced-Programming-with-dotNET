using AutoMapper;
using IntroCFAPI.DTOs;
using IntroCFAPI.EF;
using IntroCFAPI.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroCFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        PMSContext db;
        public CategoryController(PMSContext db)
        {
            this.db = db;
        }

        public Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>().ReverseMap();
            });
            return new Mapper(config);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = GetMapper().Map<List<CategoryDTO>>(db.Categories.ToList());
            return Ok(data);
        }

        [HttpGet("get/{id}")]
        public IActionResult OneCategory(int id)
        {
            var cat = db.Categories.Find(id);
            if (cat == null)
                return NotFound();

            var data = GetMapper().Map<CategoryDTO>(cat);
            return Ok(data);
        }

        [HttpPost("add")]
        public IActionResult Add(CategoryDTO c)
        {
            if (ModelState.IsValid)
            {
                var cat = GetMapper().Map<Category>(c);
                db.Categories.Add(cat);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, CategoryDTO c)
        {
            var exist = db.Categories.Find(id);
            if (exist == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                // Manual map 
                exist.Name = c.Name;

                db.SaveChanges();
                return Ok("Product updated");
            }

            return BadRequest(ModelState);
        }
    }
}
