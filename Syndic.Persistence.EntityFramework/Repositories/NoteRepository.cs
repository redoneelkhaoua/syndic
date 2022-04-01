using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class NoteRepository : IRepositoryPublication<Note>
    {
        SyndicContext context;

        public NoteRepository(SyndicContext context)
        {
            this.context = context;
        }

        public void creer(Note model)
        {
            context.Add(model);
            context.SaveChanges();
        }

        public void modifier(int id, Note model)
        {
            var note = rechercheParId(id);
            note.note= model.note;
            note.DateCreation = model.DateCreation;
            note.Typee = model.Typee;
            note.IdDossier= model.IdDossier;
            context.SaveChanges();
        }

        public Note rechercheParId(int id)
        {
            return context.Notes.FirstOrDefault(s => s.IdNote == id);
        }

        public IEnumerable<Note> rechercherTout()
        {
            return context.Notes.ToList();
        }

        public void suprimer(int id)
        {
            context.Remove(rechercheParId(id));
             context.SaveChanges();
        }

       public IEnumerable<Note> rechercheParDossier(int id)
        {
            return context.Notes.ToList().Where(e=>e.IdDossier==id);
        }
    }
}
