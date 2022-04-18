using Microsoft.EntityFrameworkCore;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        SyndicContext context;

        public NoteRepository(SyndicContext context)
        {
            this.context = context;
        }

        public Note create(Note model)
        {
            model.creationDate = DateTime.Now;
            model.IdNote = context.Notes.Count() + 1;
            context.Add(model);
            context.SaveChanges();
            return model;
        }

        public void update(int id, Note model)
        {
            var note = findById(id);
            note.note= model.note;
            note.creationDate = model.creationDate;
            note.Type = model.Type;
            note.IdCase= model.IdCase;
            context.SaveChanges();
        }

        public Note? findById(int id)
        {
            return context.Notes
                .Include(note => note.IdCaseNavigation)
                .FirstOrDefault(s => s.IdNote == id);
        }

        public IEnumerable<Note> getAll()
        {
            return context.Notes.Include(note => note.IdCaseNavigation);
        }

        public void delete(int id)
        {
            context.Remove(findById(id));
             context.SaveChanges();
        }

    }
}
