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
            context.Add(model);
            context.SaveChanges();
        }

        public void modifier(int id, Categorie model)
        {
            var categorie =  context.Categories.FirstOrDefault(s => s.IdCategorie == id);
            
            categorie.NomCategorie = model.NomCategorie;
           
              context.SaveChanges();
        }

        public Categorie rechercheParId(int id)
        {
            return context.Categories.FirstOrDefault(s => s.IdCategorie == id);
        }

        public IEnumerable<Categorie> rechercherTout()
        {
            return  context.Categories.ToList();
        }

        public void suprimer(int id)
        {
            context.Remove(rechercheParId(id));
             context.SaveChanges();
        }
    }
}
