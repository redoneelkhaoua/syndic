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
    public class VoteRepository : IRepository<Vote>
    {
        SyndicContext _context;
        ICollection<Choice> choicees;


        public VoteRepository(SyndicContext context)
        {
            _context = context;
            choicees = new List<Choice>();
        }
        public Vote? create(Vote model)
        {

            model.creationDate = DateTime.Now;
            model.IdVote = _context.Votes.Count() + 1;
            _context.Add(model);
            _context.SaveChanges();
            var vote = _context.Votes

              .Include(vote => vote.Results).ThenInclude(res => res.IdChoiceNavigation)
              .Include(vote => vote.Results).ThenInclude(res => res.IdParticipantNavigation)
              .Include(vote => vote.Choices).ThenInclude(choice => choice.Results)
              .FirstOrDefault(s => s.IdVote == model.IdVote);
               return vote;
        }

        public void update(int id, Vote model)
        {
            var vote = findById(id);
            vote.Title=model.Title;
            vote.creationDate=model.creationDate;  
            vote.IdCase=model.IdCase;
            vote.Type=model.Type;
            _context.SaveChanges();
            
        }

        public Vote findById(int id)
        {
            var vote = _context.Votes
              
                .Include(vote => vote.Results).ThenInclude(res => res.IdChoiceNavigation)
                .Include(vote => vote.Results).ThenInclude(res => res.IdParticipantNavigation)
                .Include(vote => vote.Choices).ThenInclude(choice => choice.Results)
                .FirstOrDefault(s => s.IdVote == id);
            return vote;
        }

        public IEnumerable<Vote> getAll()
        {
                return _context.Votes.Include(vote => vote.Results).ThenInclude(res => res.IdChoiceNavigation)
                .Include(vote => vote.Results).ThenInclude(res => res.IdParticipantNavigation)
                .Include(vote => vote.Choices).ThenInclude(choice=>choice.Results);

        }

        public void delete(int id)
        {
            var vote = _context.Votes.Single(e => e.IdVote == id);
            var choice = _context.Choices.Single(e => e.IdVote == vote.IdVote);

            _context.Remove(vote);
            _context.SaveChanges();

        }

        
    }
}
