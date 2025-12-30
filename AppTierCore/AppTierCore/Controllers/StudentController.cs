using BLL.DTOs;
using BLL.Services;
using DAL.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTierCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentService service;
        public StudentController(StudentService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.GetAllStudent();
            return Ok(data);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var data = service.GetStudent(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // POST
        [HttpPost("create")]
        public IActionResult Create(StudentDTO s)
        {
            var result = service.Create(s);
            if (result)
                return Ok("Student created");

            return BadRequest("Create failed");
        }

        // PUT
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, StudentDTO s)
        {
            s.Id = id;
            var result = service.Update(s);

            if (result)
                return Ok("Student updated");

            return NotFound("Student not found");
        }

        // DELETE
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result)
                return Ok("Student deleted");

            return NotFound("Student not found");
        }
    }
}
