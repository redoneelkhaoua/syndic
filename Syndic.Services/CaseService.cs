using Ardalis.GuardClauses;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;

namespace Syndic.Services
{
    public class CaseService: IService<Case>
    {
        IRepository<Case> repository;

        public CaseService(IRepository<Case> repository)
        {
            this.repository = repository;
        }

        public Case create(Case model)
        {

            Guard.Against.Null(model, nameof(model));

            return repository.create(model);
        }

        public void update(int id, Case model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            repository.update(id, model);
        }

        public Case findById(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.findById(id);
        }

        public IEnumerable<Case> getAll()
        {
            return repository.getAll();
        }

        public void delete(int id)
        {
            repository.delete(id);
        }

       
    }
}
