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
    public class FileService : IService<file>
    {
        IRepository<file> repository;

        public FileService(IRepository<file> repository)
        {
            this.repository = repository;
        }

        public file create(file model)
        {
            Guard.Against.Null(model, nameof(model));
          return  repository.create(model);
        }

        public void update(int id, file model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            repository.update(id, model);
        }

    

        public file findById(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return repository.findById(id);
        }

        public IEnumerable<file> getAll()
        {
            return repository.getAll();
        }

        public void delete(int id)
        {
            repository.delete(id);
        }
    }
}
