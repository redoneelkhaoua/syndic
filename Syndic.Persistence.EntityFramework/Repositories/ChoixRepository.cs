using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class ChoixRepository : IRepositoryChoix
    {
        SyndicContext _context;

        public ChoixRepository(SyndicContext context)
        {
            _context = context;
        }

        public void creer(Choix model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void modifier(int id, Choix model)
        {
            var choix = rechercheParId(id);
            choix.choix = model.choix;
            _context.SaveChanges();

        }

        public Choix rechercheParId(int id)
        {
            var choix = _context.Choixes.FirstOrDefault(s => s.IdChoix == id);
            return choix;
        }

        public IEnumerable<Choix> rechercherParIdVote(int IdVote)
        {
            var choix= _context.Choixes.ToList().FirstOrDefault(s => s.IdVote == IdVote);
            yield return choix;
        }

        public IEnumerable<Choix> rechercherTout()
        {
            return _context.Choixes.ToList();
        }

        public void suprimer(int id)
        {
            //_context.Remove(_context.Choixes.ToList().FirstOrDefault(s => s.IdVote == id));

        }

        public void suprimerToutParIdVote(int IdVote)
        {
            throw new NotImplementedException();
        }
    }
}
