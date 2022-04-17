using Ardalis.GuardClauses;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;


namespace Syndic.Services
{
    public class StatusService : IService<Status>
    {
        IRepository<Status> repository;

        public StatusService(IRepository<Status> repository)
        {
            this.repository = repository;
        }

        public Status create(Status model)
        {
            Guard.Against.Null(model, nameof(model));
          return  repository.create(model);
        }

        public void update(int id, Status model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            repository.update(id, model);
        }

        public Status findById(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.findById(id);
        }

        public IEnumerable<Status> getAll()
        {
            return repository.getAll();
        }

        public void delete(int id)
        { 
            repository.delete(id);
        }
    }
}
