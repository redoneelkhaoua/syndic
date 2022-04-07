using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        IService<Note> service;

        public NoteController(IService<Note> service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult<Note> RechercheTout()
        {
            return Ok(service.rechercherTout());
        }
        [HttpGet("{id}")]
        public IActionResult REchercheParId(int id)
        {
            var result = service.rechercheParId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
       
     
        [HttpPost]
        public void creer(Note note)
        {
            service.creer(note);
        }
        [HttpPut("{id}")]
        public void Modifier(int id, Note note)
        {
            service.modifier(id, note);
        }
        [HttpDelete("{id}")]
        public void suprimer(int id)
        {
            service.suprimer(id);
        }
    }
}