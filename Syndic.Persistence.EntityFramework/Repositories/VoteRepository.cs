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
        ICollection<Choix> choixes;


        public VoteRepository(SyndicContext context)
        {
            _context = context;
            choixes = new List<Choix>();
        }
        public void creer(Vote model)
        {
            //choixes = model.Choixes;

            model.DateCreation = DateTime.Now;
            model.IdVote = _context.Votes.Count() + 1;
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
            var vote = _context.Votes
              
                .Include(vote => vote.Resultats).ThenInclude(res => res.IdChoixNavigation)
                .Include(vote => vote.Resultats).ThenInclude(res => res.IdParticipantNavigation)
                .Include(vote => vote.Choixes)
                .FirstOrDefault(s => s.IdVote == id);
            return vote;
        }

        public IEnumerable<Vote> rechercherTout()
        {
            return _context.Votes.Include(vote => vote.Resultats).ThenInclude(res => res.IdChoixNavigation)
                .Include(vote => vote.Resultats).ThenInclude(res => res.IdParticipantNavigation)
                .Include(vote => vote.Choixes);

        }

        public void suprimer(int id)
        {
            var vote = _context.Votes.Single(e => e.IdVote == id);
            var choix = _context.Choixes.Single(e => e.IdVote == vote.IdVote);

            _context.Remove(vote);
            _context.SaveChanges();

        }

        
    }
}
