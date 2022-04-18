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
        public ActionResult<Note> getAllNotes()
        {
            return Ok(service.getAll());
        }
        [HttpGet("{id}")]
        public IActionResult findNoteById(int id)
        {
            var result = service.findById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
       
     
        [HttpPost]
        public IActionResult create(Note note)
        {
           return Ok(service.create(note));
        }
        [HttpPut("{id}")]
        public void update(int id, Note note)
        {
            service.update(id, note);
        }
        [HttpDelete("{id}")]
        public void delete(int id)
        {
            service.delete(id);
        }
    }
}