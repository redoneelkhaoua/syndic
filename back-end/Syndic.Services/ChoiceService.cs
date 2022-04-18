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
    public class ChoiceService : IService<Choice>
    {

        IRepository<Choice> _repository;
        public ChoiceService(IRepository<Choice> repository)
        {
            _repository = repository;
        }


        public Choice create(Choice model)
        {
            Guard.Against.Null(model, nameof(model));
          return  _repository.create(model);
        }

        public void update(int id, Choice model)
        {

            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            _repository.update(id, model);
        }

        public Choice findById(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return _repository.findById(id);
        }

        public IEnumerable<Choice> getAll()
        {
            return _repository.getAll();
        }

        public void delete(int id)
        {
            _repository.delete(id);
        }

        
    }
}
