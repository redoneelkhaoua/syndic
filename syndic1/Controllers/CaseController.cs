using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syndic.domain.Models;
using Syndic.Service.Abstraction;

namespace syndic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        IService<Case> service;
        IService<Category> CategoryService;
        IService<Status> StatusService;
        public CaseController(IService<Case> service,IService<Category>  _CategoryService, IService<Status> _StatusService)
        {
            this.service = service;
            this.CategoryService = _CategoryService;
            this.StatusService = _StatusService;
        }

        [HttpGet("Status")]
        public IActionResult getAllStatus()
        {
            return Ok(StatusService.getAll());

        }

        [HttpGet("Category")]
        public IActionResult getAllCategories()
        {
            return Ok(CategoryService.getAll());

        }
        [HttpGet]
        public  IActionResult gerAllCases()
        {
            return Ok( service.getAll());

        }
        [HttpGet("{id}")]
        public IActionResult FinCaseById(int id)
        {
            var result = service.findById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult create(Case Case)
        {
            return Ok(service.create(Case));
        }
        [HttpPut("{id}")]
        public void update(int id, Case Case)
        {
            service.update(id, Case);
        }
        [HttpDelete("{id}")]
        public void delete(int id)
        {
            service.delete(id);
        }
     
        
    }
}
