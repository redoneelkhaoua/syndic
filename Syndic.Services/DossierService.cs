using Ardalis.GuardClauses;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;

namespace Syndic.Services
{
    public class DossierService: IServiceDossier
    {
        IRepositoryDossier repository;

        public DossierService(IRepositoryDossier repository)
        {
            this.repository = repository;
        }

        public void creer(Dossier model)
        {

            Guard.Against.Null(model, nameof(model));

            repository.creer(model);
        }

        public void modifier(int id, Dossier model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            repository.modifier(id, model);
        }

        public Dossier rechercheParId(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.rechercheParId(id);
        }

        public IEnumerable<Dossier> rechercherTout()
        {
            return repository.rechercherTout();
        }

        public void suprimer(int id)
        {
            repository.suprimer(id);
        }
        public IEnumerable<Dossier> rechercheParTitle(string title)
        {
            return repository.rechercheParTitle(title);
        }
        public IEnumerable<Dossier> rechercheParCategorie(int id)
        {
            return repository.rechercheParCategorie(id);   
        }
        public IEnumerable<Dossier> rechercheParStatut(int id)
        {
            return repository.rechercheParStatut(id);
        }
       
    }
}
