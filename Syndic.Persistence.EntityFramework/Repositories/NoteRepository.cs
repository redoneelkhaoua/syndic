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

        public void creer(Note model)
        {
            model.DateCreation = DateTime.Now;
            model.IdNote = context.Notes.Count() + 1;
            context.Add(model);
            context.SaveChanges();
        }

        public void modifier(int id, Note model)
        {
            var note = rechercheParId(id);
            note.note= model.note;
            note.DateCreation = model.DateCreation;
            note.Type = model.Type;
            note.IdDossier= model.IdDossier;
            context.SaveChanges();
        }

        public Note? rechercheParId(int id)
        {
            return context.Notes
                .Include(note => note.IdDossierNavigation)
                .FirstOrDefault(s => s.IdNote == id);
        }

        public IEnumerable<Note> rechercherTout()
        {
            return context.Notes.Include(note => note.IdDossierNavigation);
        }

        public void suprimer(int id)
        {
            context.Remove(rechercheParId(id));
             context.SaveChanges();
        }

    }
}
