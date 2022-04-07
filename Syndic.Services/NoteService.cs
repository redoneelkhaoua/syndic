using Ardalis.GuardClauses;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;


namespace Syndic.Services
{
    public class NoteService : IService<Note>
    {
        IRepository<Note> repository;

        public NoteService(IRepository<Note> repository)
        {
            this.repository = repository;
        }
      

        public void creer(Note model)
        {
            Guard.Against.Null(model, nameof(model));
            repository.creer(model);
        }

        public void modifier(int id, Note model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            repository.modifier(id, model);
        }

    

        public Note rechercheParId(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.rechercheParId(id);
        }

        public IEnumerable<Note> rechercherTout()
        {
            return repository.rechercherTout();
        }

        public void suprimer(int id)
        {
            repository.suprimer(id);
        }

    }
}
