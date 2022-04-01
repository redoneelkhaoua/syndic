using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatutController : ControllerBase
    {
        IService<Statut> service;

        public StatutController(IService<Statut> service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult<Statut> RechercheTout()
        {
            return Ok(service.rechercherTout());
        }
        [HttpGet("{id}")]
        public IActionResult RechercheParId(int id)
        {
            var result = service.rechercheParId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public void Creer(Statut statut)
        {
            service.creer(statut);
        }
        [HttpPut("{id}")]
        public void Modifier(int id, Statut statut)
        {
            service.modifier(id, statut);
        }
        [HttpDelete("{id}")]
        public void suprimer(int id)
        {
            service.suprimer(id);
        }
    }
}
