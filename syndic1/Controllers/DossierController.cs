using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DossierController : ControllerBase
    {
        IServiceDossier service;

        public DossierController(IServiceDossier service)
        {
            this.service = service;
        }
        [HttpGet]
        public  IActionResult rechercheTout()
        {
            return Ok( service.rechercherTout());

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
        public void creer(Dossier dossier)
        {
            service.creer(dossier);
        }
        [HttpPut("{id}")]
        public void Modifier(int id, Dossier dossier)
        {
            service.modifier(id, dossier);
        }
        [HttpDelete("{id}")]
        public void suprimer(int id)
        {
            service.suprimer(id);
        }
        [HttpGet("title/{title}")]
        public IActionResult rechercheParTitle(string title)
        {
            var result = service.rechercheParTitle(title);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("Categorie/{categorie}")]
        public IActionResult rechercheParCategorie(int categorie)
        {
            var result = service.rechercheParCategorie(categorie);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("Statut/{statut}")]
        public IActionResult rechercheParStatut(int statut)
        {
            var result = service.rechercheParStatut(statut);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
