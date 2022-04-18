using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class fileController : ControllerBase
    {
        IService<file> service;

        public fileController(IService<file> service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult<file> getAll()
        {
            return Ok(service.getAll());
        }
        [HttpGet("{id}")]
        public IActionResult finById(int id)
        {
            var result = service.findById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]

        public file create(file file)
        {
           return service.create(file);
            
        }
        [HttpPut("{id}")]
        public void update(int id, file file)
        {
            service.update(id, file);
        }
        [HttpDelete("{id}")]
        public void delete(int id)
        {
            service.delete(id);
        }
    
    }
}
