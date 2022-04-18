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
    public class CategoryService : IService<Category>
    {
        IRepository<Category> repository;

        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public Category create(Category model)
        {
            Guard.Against.Null(model, nameof(model));
            return repository.create(model);
        }

        public void update(int id, Category model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
             repository.update(id, model);
        }

        public Category findById(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return findById(id);
        }

        public IEnumerable<Category> getAll()
        {
            return repository.getAll();
        }

        public void delete(int id)
        {
            repository.delete(id);
        }
}

}
