using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{ 
    public class DossierRepository : IRepositoryDossier
    {
         SyndicContext context;

          public DossierRepository(SyndicContext context)
          {
              this.context = context;
          }

          public void creer(Dossier model)
          {
              context.Add(model);
       
               context.SaveChanges();
          }

          public void modifier(int id, Dossier model)
          {
              var dossier = rechercheParId(id);

              dossier.Statut = model.Statut;
              dossier.Categorie = model.Categorie;
              dossier.DateCreation = model.DateCreation;
              dossier.Description = model.Description;


              context.SaveChanges();
          }

          public Dossier rechercheParId(int id)
          {
              return context.Dossiers.FirstOrDefault(s => s.IdDossier == id);
          }

          public IEnumerable<Dossier> rechercherTout()
          {
              return context.Dossiers.ToList();
          }

          public void suprimer(int id)
          {
              context.Remove(rechercheParId(id));
              context.SaveChanges();
          }
          public    IEnumerable< Dossier> rechercheParTitle(string title)
          { 
            IEnumerable<Dossier>   result = context.Dossiers.Where(s => s.Titre == title);
            return result;
          }
          public IEnumerable<Dossier> rechercheParCategorie(int id)
          {
            IEnumerable<Dossier> result = context.Dossiers.Where(s => s.Categorie == id);
            return result;
        }
          public IEnumerable<Dossier> rechercheParStatut(int id)
          {
            IEnumerable<Dossier> result = context.Dossiers.Where(s => s.Statut == id);
            return result;
        }
      }
}
