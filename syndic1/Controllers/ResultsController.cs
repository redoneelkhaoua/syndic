using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        IService<Resultat> _service;
        public ResultsController(IService<Resultat> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult RechercheTout()
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
        public void creer(Resultat resultat)
        {
            _service.creer(resultat);
        }


        [HttpPut("{id}")]
        public void Modifier(int id, Resultat resultat)
        {
            _service.modifier(id, resultat);
        }
        [HttpDelete("{id}")]
        public void suprimer(int id)
        {
            _service.suprimer(id);
        }

    }
}