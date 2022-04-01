using Ardalis.GuardClauses;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;


namespace Syndic.Services
{
    public class StatutService : IService<Statut>
    {
        IRepository<Statut> repository;

        public StatutService(IRepository<Statut> repository)
        {
            this.repository = repository;
        }

        public void creer(Statut model)
        {
            Guard.Against.Null(model, nameof(model));
            repository.creer(model);
        }

        public void modifier(int id, Statut model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            repository.modifier(id, model);
        }

        public Statut rechercheParId(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.rechercheParId(id);
        }

        public IEnumerable<Statut> rechercherTout()
        {
            return repository.rechercherTout();
        }

        public void suprimer(int id)
        { 
            repository.suprimer(id);
        }
    }
}
