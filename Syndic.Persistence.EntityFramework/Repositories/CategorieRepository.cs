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
    public class CategorieRepository : IRepository<Categorie>
    {
        SyndicContext context;

        public CategorieRepository(SyndicContext context)
        {
            this.context = context;
        }

        public void creer(Categorie model)
        {
            model.IdCategorie = context.Categories.Count() + 1;
            context.Add(model);
            context.SaveChanges();
        }

        public void modifier(int id, Categorie model)
        {
            var categorie = rechercheParId(id);
            
            categorie.NomCategorie = model.NomCategorie;
           
              context.SaveChanges();
        }

        public Categorie? rechercheParId(int id)
        {
            var categorie= context.Categories.Include(categorie => categorie.Dossiers )
                
                .ThenInclude(dossier => dossier.StatutNavigation)
                .ThenInclude(statut => statut.Dossiers)
                .FirstOrDefault(s => s.IdCategorie == id);
           
          
            return categorie;
        }

        public IEnumerable<Categorie> rechercherTout()
        {
            return  context.Categories.Include(categorie => categorie.Dossiers).ThenInclude(dossier => dossier.Fichiers)
                .Include(categorie => categorie.Dossiers).ThenInclude(dossier => dossier.Notes)
                .Include(categorie => categorie.Dossiers).ThenInclude(dossier => dossier.Votes).ThenInclude(vote =>vote.Resultats).ThenInclude(res=>res.IdChoixNavigation)
                .Include(categorie => categorie.Dossiers).ThenInclude(dossier => dossier.Votes).ThenInclude(vote => vote.Resultats).ThenInclude(res => res.IdParticipantNavigation)
                .Include(categorie => categorie.Dossiers).ThenInclude(dossier => dossier.Votes).ThenInclude(vote => vote.Choixes)
                .Include(categorie => categorie.Dossiers).ThenInclude(dossier => dossier.Fichiers)
                .ToList();
        }

        public void suprimer(int id)
        {
            context.Remove(rechercheParId(id));
             context.SaveChanges();
        }
}
}
