using IntroCoreDBFAPI.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroCoreDBFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        UniversityDbContext db;
        public DepartmentController(UniversityDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult All()
        {
            var data = db.Students.ToList();
            return Ok(data);
        }
    }
}
