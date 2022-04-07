using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichierController : ControllerBase
    {
        IService<Fichier> service;

        public FichierController(IService<Fichier> service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult<Fichier> RechercheTout()
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
        public void creer(Fichier fichier)
        {
            service.creer(fichier);
        }
        [HttpPut("{id}")]
        public void Modifier(int id, Fichier fichier)
        {
            service.modifier(id, fichier);
        }
        [HttpDelete("{id}")]
        public void suprimer(int id)
        {
            service.suprimer(id);
        }
    
    }
}
