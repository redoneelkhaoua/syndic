using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        IService<Vote> _service;


        public VoteController (IService<Vote> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Vote> getAllVotes()
        {
            return Ok(_service.getAll());
        }


        [HttpGet("{id}")]
        public IActionResult findById(int id)
        {
            var result = _service.findById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


       
        [HttpPost]
        public Vote create(Vote vote)
        {
           return _service.create(vote);
        }


        [HttpPut("{id}")]
        public void update(int id, Vote vote)
        {
            _service.update(id, vote);
        }
        [HttpDelete("{id}")]
        public void delete(int id)
        {
            _service.delete(id);
        }

    }
}
