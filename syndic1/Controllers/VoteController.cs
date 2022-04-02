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
        public ActionResult<Vote> RechercheTout()
        {
            return Ok(_service.rechercherTout());
        }


        [HttpGet("{id}")]
        public IActionResult REchercheParId(int id)
        {
            var result = _service.rechercheParId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


       
        [HttpPost]
        public void creer(Vote vote)
        {
            _service.creer(vote);
        }


        [HttpPut("{id}")]
        public void Modifier(int id, Vote vote)
        {
            _service.modifier(id, vote);
        }
        [HttpDelete("{id}")]
        public void suprimer(int id)
        {
            _service.suprimer(id);
        }

    }
}
