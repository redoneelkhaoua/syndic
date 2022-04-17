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
    public class resultsRepository : IRepository<results>
    {

        SyndicContext _context;
        

        public resultsRepository(SyndicContext context)
        {
            _context = context;
        }
        public results create(results model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model;   
        }

        public void update(int id, results model)
        {
            var results = findById(id);
            results.IdVote=model.IdVote;
            results.IdParticipant=model.IdParticipant;
            results.IdChoice=model.IdChoice;
            
            _context.SaveChanges();

        }

        public results findById(int id)
        {

            var _results = _context.results.FirstOrDefault(s => s.IdParticipant == id);
            return _results;
        }

        public IEnumerable<results> getAll()
        {
            return _context.results.Include(res=>res.IdParticipantNavigation).Include(res => res.IdVoteNavigation).ToList();
        }

        public void delete(int id)
        {
            
            _context.Remove(findById(id));
            _context.SaveChanges();
        }

    }
}
