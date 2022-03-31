using Ardalis.GuardClauses;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Services
{
    public class CategorieService : IService<Categorie>
    {
        IRepository<Categorie> repository;

        public CategorieService(IRepository<Categorie> repository)
        {
            this.repository = repository;
        }

        public void creer(Categorie model)
        {
            Guard.Against.Null(model, nameof(model));
             repository.creer(model);
        }

        public void modifier(int id, Categorie model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
             repository.modifier(id, model);
        }

        public Categorie rechercheParId(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.rechercheParId(id);
        }

        public IEnumerable<Categorie> rechercherTout()
        {
            return repository.rechercherTout();
        }

        public void suprimer(int id)
        {
            repository.suprimer(id);
        }
    }
}
