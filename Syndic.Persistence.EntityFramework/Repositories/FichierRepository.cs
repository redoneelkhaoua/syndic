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
    public class FichierRepository : IRepository<Fichier>
    {
        SyndicContext context;

        public FichierRepository(SyndicContext context)
        {
            this.context = context;
        }

        public void creer(Fichier model)
        {
            model.DateCreation = DateTime.Now;
            model.IdFichier = context.Fichiers.Count() + 1;
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
            fichier.Type = model.Type;



            context.SaveChanges();
        }

   

        public Fichier? rechercheParId(int id)
        {
            return context.Fichiers
                .Include(fichier=>fichier.IdDossierNavigation)

                .FirstOrDefault(s => s.IdFichier == id);
        }

        public IEnumerable<Fichier> rechercherTout()
        {
            return context.Fichiers.Include(fichier => fichier.IdDossierNavigation);
        }

        public void suprimer(int id)
        {
            context.Remove(rechercheParId(id));
            context.SaveChanges();
        }
    }
}
