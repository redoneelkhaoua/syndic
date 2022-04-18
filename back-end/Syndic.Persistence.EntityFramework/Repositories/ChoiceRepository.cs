using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class ChoiceRepository : IRepository<Choice>
    {
        SyndicContext _context;

        public ChoiceRepository(SyndicContext context)
        {
            _context = context;
        }

        public Choice create(Choice model)
        {
            model.IdChoice = _context.Choices.Count() + 1;
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void update(int id, Choice model)
        {
            var choice = findById(id);
            choice.choice = model.choice;
            _context.SaveChanges();

        }

        public Choice findById(int id)
        {
            var choice = _context.Choices.FirstOrDefault(s => s.IdChoice == id);
            return choice;
        }

        public IEnumerable<Choice> findByIdVote(int IdVote)
        {
            var choice= _context.Choices.ToList().FirstOrDefault(s => s.IdVote == IdVote);
            yield return choice;
        }

        public IEnumerable<Choice> getAll()
        {
            return _context.Choices.ToList();
        }

        public void delete(int id)
        {
            //_context.Remove(_context.Choicees.ToList().FirstOrDefault(s => s.IdVote == id));

        }

      
    }
}
