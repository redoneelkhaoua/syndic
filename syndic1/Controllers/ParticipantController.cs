using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : Controller
    {
        IService<Participant> _service;
        public ParticipantController(IService<Participant> service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ActionResult<Participant> RechercheTout()
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
        public void creer(Participant participant)
        {
            _service.creer(participant);
        }


        [HttpPut("{id}")]
        public void Modifier(int id, Participant participant)
        {
            _service.modifier(id, participant);
        }


        [HttpDelete("{id}")]
        public void suprimer(int id)
        {
            _service.suprimer(id);
        }
    }
}
