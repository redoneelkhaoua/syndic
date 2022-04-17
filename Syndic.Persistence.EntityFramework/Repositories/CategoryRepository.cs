using Microsoft.EntityFrameworkCore;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        SyndicContext context;

        public CategoryRepository(SyndicContext context)
        {
            this.context = context;
        }

        public Category create(Category model)
        {
            model.IdCategory = context.Categories.Count() + 1;
            context.Add(model);
            context.SaveChanges();

            return model;
        }

        public void update(int id, Category model)
        {
            var category = findById(id);
            
            category.CategoryName = model.CategoryName;
           
              context.SaveChanges();
        }

        public Category? findById(int id)
        {
            var category= context.Categories.Include(category => category.Cases)
                
                .ThenInclude(Case => Case.StatusNavigation)
                .ThenInclude(status => status.Cases)
                .FirstOrDefault(s => s.IdCategory == id);
           
          
            return category;
        }

        public IEnumerable<Category> getAll()
        {
            return  context.Categories.Include(category => category.Cases).ThenInclude(Case => Case._files)
                .Include(category => category.Cases).ThenInclude(Case => Case.Notes)
                .Include(category => category.Cases).ThenInclude(Case => Case.Votes).ThenInclude(vote =>vote.Results).ThenInclude(res=>res.IdChoiceNavigation)
                .Include(category => category.Cases).ThenInclude(Case => Case.Votes).ThenInclude(vote => vote.Results).ThenInclude(res => res.IdParticipantNavigation)
                .Include(category => category.Cases).ThenInclude(Case => Case.Votes).ThenInclude(vote => vote.Choices)
                .Include(category => category.Cases).ThenInclude(Case => Case._files)
                .ToList();
        }

        public void delete(int id)
        {
            context.Remove(findById(id));
             context.SaveChanges();
        }
}
}
