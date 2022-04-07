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
    public class DossierRepository : IRepository<Dossier>
    {
         SyndicContext context;
      

          public DossierRepository(SyndicContext context)
          {
              this.context = context;
              
          }

          public void creer(Dossier model)
          {
            

            model.DateCreation = DateTime.Now;
            model.IdDossier=context.Dossiers.Count()+1;
            
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

          public Dossier? rechercheParId(int id)
          {
             return context.Dossiers.Include(dossier => dossier.Fichiers)
                .Include(dossier => dossier.Notes)
                .Include(dossier => dossier.Votes).ThenInclude(vote => vote.Resultats).ThenInclude(res => res.IdChoixNavigation)
                .Include(dossier => dossier.Votes).ThenInclude(vote => vote.Resultats).ThenInclude(res => res.IdParticipantNavigation)
                .Include(dossier => dossier.Votes).ThenInclude(vote => vote.Choixes)
                .Include(dossier => dossier.Fichiers)
                .FirstOrDefault(s => s.IdDossier == id);
         
           
          }

          public IEnumerable<Dossier> rechercherTout()
          {
              return context.Dossiers
                .Include(dossier => dossier.Fichiers)
                .Include(dossier => dossier.Notes)
                .Include(dossier => dossier.Votes).ThenInclude(vote => vote.Resultats).ThenInclude(res => res.IdChoixNavigation)
                .Include(dossier => dossier.Votes).ThenInclude(vote => vote.Resultats).ThenInclude(res => res.IdParticipantNavigation)
                .Include(dossier => dossier.Votes).ThenInclude(vote => vote.Choixes)
                .Include(dossier => dossier.Fichiers);
          }

          public void suprimer(int id)
          {
              context.Remove(rechercheParId(id));
              context.SaveChanges();
          }
     
      }
}
