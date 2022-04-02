using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Persistence.EntityFramework.Repositories
{
    public class ParticipantRepository : IRepository<Participant>
    {

        SyndicContext _context;

        public ParticipantRepository(SyndicContext context)
        {
            _context = context;
        }
        public void creer(Participant model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

       

        public void modifier(int id, Participant model)
        {
            var Participant = rechercheParId(id);
            Participant.NomParticipant = model.NomParticipant;
            
            _context.SaveChanges();

        }

        public Participant rechercheParId(int id)
        {
            var participant = _context.Participants.FirstOrDefault(s => s.IdParticipant == id);
            return participant;
        }

        public IEnumerable<Participant> rechercherTout()
        {
            return _context.Participants.ToList();
        }

        public void suprimer(int id)
        {
            _context.Remove(rechercheParId(id));
            _context.SaveChanges();
        }
    }
}
