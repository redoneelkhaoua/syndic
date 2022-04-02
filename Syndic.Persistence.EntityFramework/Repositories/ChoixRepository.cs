using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class ChoixRepository : IRepository<Choix>
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
            var choix = _context.Choix.FirstOrDefault(s => s.IdChoix == id);
            return choix;
        }

        public IEnumerable<Choix> rechercherTout()
        {
            return _context.Choix.ToList();
        }

        public void suprimer(int id)
        {
            _context.Remove(rechercheParId(id));
            
        }
    }
}
