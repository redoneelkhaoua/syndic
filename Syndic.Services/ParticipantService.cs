using Ardalis.GuardClauses;
using Syndic.domain.Models;
using Syndic.Repository.Abstraction;
using Syndic.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndic.Services
{
    public class ParticipantService : IService<Participant>
    {
        IRepository<Participant> _repository;
        public ParticipantService(IRepository<Participant> repository)
        {
            _repository = repository;
        }
        public void creer(Participant model)
        {
            Guard.Against.Null(model, nameof(model));
            _repository.creer(model);
        }

        public void modifier(int id, Participant model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            _repository.modifier(id, model);
        }

        public Participant rechercheParId(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return _repository.rechercheParId(id);
        }

        public IEnumerable<Participant> rechercherTout()
        {
            return _repository.rechercherTout();
        }

        public void suprimer(int id)
        {
            _repository.suprimer(id);
        }
    }
}
