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
        public Participant create(Participant model)
        {
            model.IdParticipant = _context.Participants.Count() + 1;
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void update(int id, Participant model)
        {
            var participant = findById(id);

            participant.participantName = model.participantName;

            _context.SaveChanges();
        }

        public Participant findById(int id)
        {
            return _context.Participants.FirstOrDefault(s => s.IdParticipant == id);
        }

        public IEnumerable<Participant> getAll()
        {
            return _context.Participants.ToList();
        }

        public void delete(int id)
        {
            
            _context.Remove(findById(id));
            _context.SaveChanges();
        }
    }
}