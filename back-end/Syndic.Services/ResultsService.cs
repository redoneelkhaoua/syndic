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
    public class resultsService : IService<results>
    {
        IRepository<results> _repository;

        public resultsService(IRepository<results> repository)
        {
            _repository = repository;
        }
        public results create(results model)
        {
            Guard.Against.Null(model, nameof(model));
         return   _repository.create(model);
        }

        public void update(int id, results model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            _repository.update(id, model);
        }

        public results findById(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return _repository.findById(id);
        }

        public IEnumerable<results> getAll()
        {
            return _repository.getAll();
        }

        public void delete(int id)
        {
            _repository.delete(id);
        }
    }
}
