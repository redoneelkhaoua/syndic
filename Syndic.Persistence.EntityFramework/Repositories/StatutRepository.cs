
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class StatutRepository : IRepository<Statut>
    {
         SyndicContext context;

         public StatutRepository(SyndicContext context)
         {
             this.context = context;
         }

         public void creer(Statut model)
         {
             model.IdStatut=context.Statuts.Count()+1;
             context.Add(model);
             context.SaveChanges();
         }

         public void modifier(int id, Statut model)
         {
             var categorie = rechercheParId(id);

             categorie.NomStatut = model.NomStatut;

             context.SaveChanges();
         }

         public Statut rechercheParId(int id)
         {
             return context.Statuts.FirstOrDefault(s => s.IdStatut == id);
         }

         public IEnumerable<Statut> rechercherTout()
         {
             return context.Statuts.ToList();
         }

         public void suprimer(int id)
         {
             context.Remove(rechercheParId(id));
             context.SaveChanges();
         }
     }
}
