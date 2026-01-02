using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTierDemo.Controllers
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
        public IActionResult Get()
        {
            var data = service.GetAll();
            return Ok(data);
        }

        [HttpGet("get/id/{id}")]
        public IActionResult GetSingleStudent(int id)
        {
            var data = service.GetbyId(id);
            return Ok(data);
        }

        [HttpGet("Scholar")]
        public IActionResult ScholarStudent()
        {
            var data = service.Scholar();
            return Ok(data);
        }
    }
}
