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
    public class VoteService : IService<Vote>
    {
        IRepository<Vote> _repository;
        public VoteService(IRepository<Vote> repository)
        {
            _repository = repository;
        }
        public void creer(Vote model)
        {
            Guard.Against.Null(model, nameof(model));
            _repository.creer(model);
        }

        public void modifier(int id, Vote model)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            Guard.Against.Null(model, nameof(model));
            _repository.modifier(id, model);
        }

        public Vote rechercheParId(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return _repository.rechercheParId(id);
        }

        public IEnumerable<Vote> rechercherTout()
        {
            return _repository.rechercherTout();
        }

        public void suprimer(int id)
        {
            _repository.suprimer(id); 
        }
    }
}
