using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class FichierRepository : IRepositoryPublication<Fichier>
    {
        SyndicContext context;

        public FichierRepository(SyndicContext context)
        {
            this.context = context;
        }

        public void creer(Fichier model)
        {
            context.Add(model);
            context.SaveChanges();
        }

        public void modifier(int id, Fichier model)
        {
            var fichier = rechercheParId(id);

            fichier.IdDossier = model.IdDossier;
            fichier.DateCreation = model.DateCreation;
            fichier.Note=model.Note;
            fichier.fichier = model.fichier;
            fichier.Typee = model.Typee;



            context.SaveChanges();
        }

        public IEnumerable<Fichier> rechercheParDossier(int id)
        {
            return context.Fichiers.ToList().Where(e=>e.IdDossier==id);
        }

        public Fichier rechercheParId(int id)
        {
            return context.Fichiers.FirstOrDefault(s => s.IdFichier == id);
        }

        public IEnumerable<Fichier> rechercherTout()
        {
            return context.Fichiers.ToList();
        }

        public void suprimer(int id)
        {
            context.Remove(rechercheParId(id));
            context.SaveChanges();
        }
    }
}
