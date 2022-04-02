using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    public class ChoixController : Controller
    {
        IService<Choix> _service;
        public ChoixController(IService<Choix> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Choix> RechercheTout()
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
        public void creer(Choix choix)
        {
            _service.creer(choix);
        }


        [HttpPut("{id}")]
        public void Modifier(int id, Choix choix)
        {
            _service.modifier(id, choix);
        }
        [HttpDelete("{id}")]
        public void suprimer(int id)
        {
            _service.suprimer(id);
        }
    }
}
