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
    public class ProductController : ControllerBase
    {
        PMSContext db;
        public ProductController(PMSContext db)
        {
            this.db = db;
        }

        public Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>().ReverseMap();
            });
            return new Mapper(config);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = GetMapper().Map<List<ProductDTO>>(db.Products.ToList());
            return Ok(data);
        }

        [HttpGet("product{id}")]
        public IActionResult OneProduct(ProductDTO p, int Id)
        {
            var data = db.Products.Find(p.Id);
            return Ok(data);
        }

        [HttpPost("add")]
        public IActionResult Add(ProductDTO p)
        {
            if (ModelState.IsValid)
            {
                var product = GetMapper().Map<Product>(p);
                db.Products.Add(product);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost("update{id}")]
        public IActionResult Update(ProductDTO p, int Id)
        {
            var data = db.Products.Find(p.Id);
            if (ModelState.IsValid)
            {
                var product = GetMapper().Map<ProductDTO, Product>(p, data);
                db.Products.Add(product);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
