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

        public VoteRepository(SyndicContext context)
        {
            _context = context;
        }
        public void creer(Vote model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void modifier(int id, Vote model)
        {
            var vote = rechercheParId(id);
            vote.Titre=model.Titre;
            vote.DateCreation=model.DateCreation;  
            vote.IdDossier=model.IdDossier;
            vote.Type=model.Type;
            _context.SaveChanges();
            
        }

        public Vote rechercheParId(int id)
        {
            var vote = _context.Votes.FirstOrDefault(s => s.IdVote == id);
            return vote;
        }

        public IEnumerable<Vote> rechercherTout()
        {
            return _context.Votes.ToList();
        }

        public void suprimer(int id)
        {
            
            _context.Remove(rechercheParId(id));
            _context.SaveChanges();
        }

        
    }
}
