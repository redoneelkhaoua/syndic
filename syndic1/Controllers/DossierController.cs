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
        IService<Categorie> categorieService;
        IService<Statut> statutService;
        public DossierController(IServiceDossier service,IService<Categorie>  _categorieService, IService<Statut> _statutService)
        {
            this.service = service;
            this.categorieService = _categorieService;
            this.statutService = _statutService;
        }

        [HttpGet("Statut")]
        public IActionResult rechercheToutStatut()
        {
            return Ok(statutService.rechercherTout());

        }

        [HttpGet("Categorie")]
        public IActionResult rechercheToutCategorie()
        {
            return Ok(categorieService.rechercherTout());

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
        
    }
}
