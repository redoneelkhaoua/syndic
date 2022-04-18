using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        IService<results> _service;
        public ResultsController(IService<results> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult getAllResults()
        {
            return Ok(_service.getAll());
        }

        
        [HttpGet("{id}")]
        public IActionResult findById(int id)
        {
            var _result = _service.findById(id);
            if (_result == null)
            {
                return NotFound();
            }
            return Ok(_result);
        }



        [HttpPost]
        public void create(results _results)
        {
            _service.create(_results);
        }


        [HttpPut("{id}")]
        public void update(int id, results _results)
        {
            _service.update(id, _results);
        }
        [HttpDelete("{id}")]
        public void update(int id)
        {
            _service.delete(id);
        }

    }
}