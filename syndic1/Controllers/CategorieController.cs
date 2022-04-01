using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
      IService<Categorie> service;

         public CategorieController(IService<Categorie> service)
         {
             this.service = service;
         }
         [HttpGet]
         public ActionResult<Categorie> RechercheTout()
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
         public void creer(Categorie categorie)
         {
             service.creer(categorie);
         }
         [HttpPut("{id}")]
         public void Modifier(int id,Categorie categorie)
         {
             service.modifier(id,categorie);
         }
         [HttpDelete("{id}")]
         public void suprimer(int id)
         {
             service.suprimer(id);
         }

    }
}
