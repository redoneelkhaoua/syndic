using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class ResultatRepository : IRepository<Resultat>
    {

        SyndicContext _context;

        public ResultatRepository(SyndicContext context)
        {
            _context = context;
        }
        public void creer(Resultat model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void modifier(int id, Resultat model)
        {
            var resultat = rechercheParId(id);
            resultat.IdVote=model.IdVote;
            resultat.IdParticipant=model.IdParticipant;
            resultat.IdChoix=model.IdChoix;
            
            _context.SaveChanges();

        }

        public Resultat rechercheParId(int id)
        {
            
            return null;
        }

        public IEnumerable<Resultat> rechercherTout()
        {
            return _context.Resultats.ToList();
        }

        public void suprimer(int id)
        {
            _context.Remove(rechercheParId(id));
            _context.SaveChanges();
        }
    }
}
