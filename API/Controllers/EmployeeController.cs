using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MyDbContext _context;

        public EmployeeController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllEmployee()
        {
            return Ok(_context.Employyes.ToList());
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_context.Employyes.Find(id));
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateEmployee(Employye ep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ep.Id = Guid.NewGuid();
            _context.Employyes.Add(ep);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var findExist = _context.Employyes.Find(id);
            if (findExist == null)
            {
                return BadRequest();
            }
            _context.Employyes.Remove(findExist);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("Update/{id}")]
        public IActionResult Update(Guid id, string name,string address,int age)
        {
            var findExist = _context.Employyes.Find(id);
            if (findExist == null)
            {
                return BadRequest();
            }

            findExist.Name = name;
            findExist.Address = address;
            findExist.Age = age;
            _context.SaveChanges();
            return Ok();
        }
    }
}
